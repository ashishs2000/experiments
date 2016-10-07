using System;
using log4net;

namespace SqlDb.Baseline.Helpers
{
    public static class LogFile
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(LogFile));

        public static void Info(string log)
        {
            Logger.Info(log);
        }

        public static void Warning(string log)
        {
            Logger.Warn(log);
        }

        public static void Error(string log)
        {
            Logger.Error(log);
        }

        public static void Error(Exception exception)
        {
            Logger.Error(exception.Message);
            Logger.Error(exception.StackTrace);
        }

        public static void HeaderH1(string heading)
        {
            Info("#".PadRight(100, '#'));
            Info($"## {heading}");
            Info("#".PadRight(100, '#'));
        }

        public static void HeaderH2(string heading)
        {
            Info(string.Empty.PadRight(50, '*'));
            Info($"*** {heading}");
            Info(string.Empty.PadRight(50, '*'));
        }

        public static void HeaderH3(string heading)
        {
            Info($"-- [[ {heading} ]] ------------------");
        }
    }
}