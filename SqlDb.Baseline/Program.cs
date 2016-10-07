using System;
using System.Collections.Generic;
using System.Linq;
using SqlDb.Baseline.ConfigSections;

namespace SqlDb.Baseline
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var configurations = new AppConfiguration();
                foreach (var database in configurations.Databases)
                {
                    Logger.LogInfo($"Start Processing '{database}'");
                    Logger.SetIndent();

                    using (var runner = new DatabaseRunner(configurations, database))
                        runner.Execute();

                    Logger.ResetAllIndent();
                    Logger.LogInfo($"Complete Processing '{database}'");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
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
