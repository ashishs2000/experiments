using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using SqlDb.Baseline.ConfigSections;
using SqlDb.Baseline.Helpers;
using SqlDb.Baseline.Models;

namespace SqlDb.Baseline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var command = GetCommand(args);

                LogFile.HeaderH1($"Start Execution at {DateTime.Now}");

                var configurations = new AppConfiguration(command);
                var scripts = QueryScripts.Load(configurations);

                foreach (var database in configurations.Databases)
                {
                    var dbConfiguration = configurations.GetDatabaseSetting(database);
                    if(dbConfiguration.Skip)
                        continue;

                    SummaryRecorder.Switch(database);
                    LogFile.HeaderH2($"Start Processing '{database}'");
                    ConsoleLogger.LogInfo($"Start Processing '{database}'");
                    ConsoleLogger.SetIndent();

                    using (var runner = new DatabaseRunner(configurations, dbConfiguration, scripts))
                        runner.Execute(command == CommandType.Insert);

                    ConsoleLogger.ResetAllIndent();
                    ConsoleLogger.LogInfo($"Complete Processing '{database}'");
                }

                SummaryRecorder.Print();
            }
            catch (Exception ex)
            {
                LogFile.Error(ex);
                Console.Out.WriteLine(ex.Message);
            }
        }

        private static CommandType GetCommand(IReadOnlyList<string> args)
        {
            if (args != null && args.Count > 0)
                return Regex.IsMatch(args[0], "s.*", RegexOptions.IgnoreCase)
                    ? CommandType.Select
                    : CommandType.Insert;

            Console.Out.WriteLine("Please select type of command");
            Console.Out.WriteLine("     1. Select Statement");
            Console.Out.WriteLine("     2. Insert Statement");
            Console.Out.Write("Selected Option : ");
            var output = Console.ReadKey();
            Console.Out.WriteLine("");
            switch (output.KeyChar)
            {
                case '1':
                    return CommandType.Select;
                case '2':
                    return CommandType.Insert;
                default:
                    Console.Clear();
                    Console.Out.WriteLine("Invalid Option selected");
                    return GetCommand(args);
            }
        }
    }

    public enum CommandType
    {
        Insert,
        Select
    }
}
