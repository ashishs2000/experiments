using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using SqlDb.Baseline.ConfigSections;
using SqlDb.Baseline.Helpers;

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
                foreach (var database in configurations.Databases)
                {
                    var dbConfiguration = configurations.GetDatabaseSetting(database);
                    if(dbConfiguration.Skip)
                        continue;

                    SummaryRecorder.Switch(database);
                    LogFile.HeaderH2($"Start Processing '{database}'");
                    Logger.LogInfo($"Start Processing '{database}'");
                    Logger.SetIndent();

                    using (var runner = new DatabaseRunner(configurations, dbConfiguration))
                        runner.Execute(command == CommandType.Insert);

                    Logger.ResetAllIndent();
                    Logger.LogInfo($"Complete Processing '{database}'");
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
    
    public static class Logger
    {
        private static readonly ConsoleLogger _logger = new ConsoleLogger();
        private static readonly Stack<int> _indent = new Stack<int>();

        public static void SetIndent()
        {
            _indent.Push(CurrentIndent + 5);
        }

        public static void ResetIndent()
        {
            if (_indent.Any())
                _indent.Pop();
        }

        public static void ResetAllIndent()
        {
            _indent.Clear();
        }

        public static void LogInfo(string log, params object[] args)
        {
            _logger.WriteLine(LogType.Info, Format(log), args);
        }

        public static void LogWarning(string log, params object[] args)
        {
            _logger.WriteLine(LogType.Warning, Format(log), args);
        }

        public static void LogError(string log, params object[] args)
        {
            _logger.WriteLine(LogType.Error, Format(log), args);
        }

        private static string Format(string log)
        {
            return $"{string.Empty.PadRight(CurrentIndent, ' ')}{log}";
        }

        public static int CurrentIndent => _indent.Any() ? _indent.First() : 0;
    }

    public enum LogType
    {
        Info,
        Warning,
        Error
    }
    
    public class ConsoleLogger
    {
        public void WriteLine(LogType logType, string log, params object[] args)
        {
            Console.Out.WriteLine(log, args);
        }

        public void Write(LogType logType, string log, params object[] args)
        {
            Console.Out.Write(log, args);
        }

        public string PromptUser(string message, params object[] args)
        {
            WriteLine(LogType.Info,message, args);
            return Console.ReadLine();
        }
    }
}
