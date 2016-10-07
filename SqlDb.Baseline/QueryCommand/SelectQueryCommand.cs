using System.Text;
using SqlDb.Baseline.ConfigSections;
using SqlDb.Baseline.Models;

namespace SqlDb.Baseline.QueryCommand
{
    public class SelectQueryCommand : BaseQueryCommand
    {
        private readonly IApplicationSetting _appSettings;
        private readonly DatabaseElementConfiguration _dbSettings;

        public override string BeforeTemplate { get; }
        public override string AfterTemplate { get; }

        public SelectQueryCommand(IApplicationSetting appSettings, DatabaseElementConfiguration dbConfiguration)
            : base(appSettings)
        {
            _appSettings = appSettings;
            _dbSettings = dbConfiguration;

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