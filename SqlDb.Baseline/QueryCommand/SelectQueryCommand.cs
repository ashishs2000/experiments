using System.Text;
using SqlDb.Baseline.ConfigSections;
using SqlDb.Baseline.Models;

namespace SqlDb.Baseline.QueryCommand
{
    public class SelectQueryCommand : BaseQueryCommand
    {
        public override string BeforeTemplate { get; }
        public override string AfterTemplate { get; }

        public SelectQueryCommand(IApplicationSetting appSettings)
            : base(appSettings)
        {
            BeforeTemplate = appSettings.SelectOutputBeforeTemplate;
            AfterTemplate = appSettings.SelectOutputAfterTemplate;
        }

        public override string CreateQuery(DbTable targetTable, string targetDb, string alias, bool excludeInsert = false)
        {
            var builder = new StringBuilder();
            builder.AppendLine($"SELECT {targetTable.Csv(alias)}");
            builder.AppendLine($"FROM {targetTable.FullName} {alias}");
            return builder.ToString();
        }
    }
}