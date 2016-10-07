using System.Text;
using SqlDb.Baseline.ConfigSections;
using SqlDb.Baseline.Models;

namespace SqlDb.Baseline.QueryCommand
{
    public class InsertQueryCommand : BaseQueryCommand
    {
        private readonly IApplicationSetting _appSettings;
        private readonly DatabaseElementConfiguration _dbSettings;

        public override string BeforeTemplate { get; }
        public override string AfterTemplate { get; }

        public InsertQueryCommand(IApplicationSetting appSettings, DatabaseElementConfiguration dbConfiguration)
            : base(appSettings)
        {
            _appSettings = appSettings;
            _dbSettings = dbConfiguration;

            BeforeTemplate = appSettings.InsertOutputBeforeTemplate;
            AfterTemplate = appSettings.InsertOutputAfterTemplate;
        }

        public override string CreateQuery(DbTable targetTable, string targetDb, string alias, bool excludeInsert = false)
        {
            var builder = new StringBuilder();

            if (targetTable.HasIdentiyColumn)
                builder.AppendLine($"SET IDENTITY_INSERT {_dbSettings.TargetDatabase}.{targetTable.FullName} ON");

            if (!excludeInsert)
                builder.AppendLine($"INSERT INTO {targetDb}.{targetTable.FullName} ({targetTable.Csv()})");

            if (targetTable.HasIdentiyColumn)
                builder.AppendLine($"SET IDENTITY_INSERT {_dbSettings.TargetDatabase}.{targetTable.FullName} OFF");

            builder.AppendLine($"SELECT {targetTable.Csv(alias)}");
            builder.AppendLine($"FROM {targetTable.FullName} {alias}");
            return builder.ToString();
        }
    }
}