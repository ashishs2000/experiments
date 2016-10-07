using System;
using System.Collections.Generic;
using System.Linq;
using log4net;
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
                Console.Out.WriteLine("Do you want to create 'Select' or 'Insert' output file ? (type s or i)");
                var output = Console.ReadLine();
                
                LogFile.HeaderH1($"Start Execution at {DateTime.Now}");
                   
                var configurations = new AppConfiguration();
                foreach (var database in configurations.Databases)
                {
                    var dbConfiguration = configurations.GetDatabaseSetting(database);
                    if(dbConfiguration.Skip)
                        continue;

                    SummaryRecorder.Switch(database);
                    LogFile.HeaderH2($"Start Processing '{database}'");
                    Logger.LogInfo($"Start Processing '{database}'");
                    Logger.SetIndent();

                    using (var runner = new DatabaseRunner(configurations, dbConfiguration, database))
                        runner.Execute(output != "s");

                    Logger.ResetAllIndent();
                    Logger.LogInfo($"Complete Processing '{database}'");
                }

                SummaryRecorder.Print();
            }
            catch (Exception ex)
            {
                LogFile.Error(ex);
            }
        }
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
