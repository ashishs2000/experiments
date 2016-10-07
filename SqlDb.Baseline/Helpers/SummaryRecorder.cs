using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace SqlDb.Baseline.Helpers
{
    public class SummaryRecorder
    {
        private const string SUMMARY_KEY = "CURRENT_SUMMARY_INFO";
        private static readonly IList<SummaryRecorder> Summaries = new List<SummaryRecorder>();
         
        public static SummaryRecorder Current
        {
            get { return (SummaryRecorder)CallContext.GetData(SUMMARY_KEY); }
            set { CallContext.SetData(SUMMARY_KEY, value); }
        }

        public static void Switch(string database)
        {
            Summaries.Add(Current = new SummaryRecorder(database));
        }

        public static void Print()
        {
            foreach (var summary in Summaries)
            {
                LogFile.Info(summary.ToString());
                Logger.LogInfo(summary.ToString());
            }
        }

        public SummaryRecorder(string database)
        {
            Database = database;
        }

        public string Database { get; private set; }
        public int TableCount { get; set; }
        public int ViewCount { get; set; }

        public int DatabaseRelationCount { get; set; }
        public int CustomDatabaseRelationCount { get; set; }

        public int IgnoreTableCount { get; set; }
        public int MigrationTableCount { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine($"--{Database}--");
            builder.AppendLine($"   Total Tables - {TableCount}");
            builder.AppendLine($"   Total Views - {ViewCount}");
            builder.AppendLine($"   Total Sql Relations Found - {DatabaseRelationCount}");
            builder.AppendLine($"   Total Possible Relation Found - {CustomDatabaseRelationCount}");
            builder.AppendLine($"   Table Ignore for Migration - {IgnoreTableCount}");
            builder.AppendLine($"   Total Tables Migrated - {MigrationTableCount}");
            builder.AppendLine("".PadRight(50,'-'));

            return builder.ToString();
        }
    }
}