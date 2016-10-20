using System;
using System.Collections.Generic;
using System.Linq;

namespace SqlDb.Baseline.Helpers
{
    public class ConsoleLogger
    {
        private static readonly Stack<int> Indent = new Stack<int>();
        public static int CurrentIndent => Indent.Any() ? Indent.First() : 0;

        public static void SetIndent()
        {
            Indent.Push(CurrentIndent + 5);
        }

        public static void ResetIndent()
        {
            if (Indent.Any())
                Indent.Pop();
        }

        public static void ResetAllIndent()
        {
            Indent.Clear();
        }

        public static void LogInfo(string log, params object[] args)
        {
            WriteLine(LogType.Info, Format(log), args);
        }

        public static void LogWarning(string log, params object[] args)
        {
            WriteLine(LogType.Warning, Format(log), args);
        }

        public static void LogError(string log, params object[] args)
        {
           WriteLine(LogType.Error, Format(log), args);
        }
        
        public string PromptUser(string message, params object[] args)
        {
            WriteLine(LogType.Info, message, args);
            return Console.ReadLine();
        }

        private static void WriteLine(LogType logType, string log, params object[] args)
        {
            Console.Out.WriteLine(Format(log), args);
        }

        private static string Format(string log)
        {
            return $"{string.Empty.PadRight(CurrentIndent, ' ')}{log}";
        }
    }

    public enum LogType
    {
        Info,
        Warning,
        Error
    }
}