using System.Text;
using SqlDb.Baseline.ConfigSections;
using SqlDb.Baseline.Models;

namespace SqlDb.Baseline.QueryCommand
{
    public class InsertQueryCommand : BaseQueryCommand
    {
        private readonly IApplicationSetting _appSettings;
        private readonly DatabaseElementConfiguration _dbSettings;
        public sealed override SqlTemplate Template { get; set; }

        public InsertQueryCommand(IApplicationSetting appSettings, DatabaseElementConfiguration dbConfiguration)
            : base(appSettings)
        {
            _appSettings = appSettings;
            _dbSettings = dbConfiguration;

            Template = appSettings.InsertTemplate;
        }

        public override string SurroundStatement(DbTable targetTable, string statement)
        {
            var builder = new StringBuilder();

            if (targetTable.HasIdentiyColumn)
                builder.AppendLine($"SET IDENTITY_INSERT {_dbSettings.TargetDatabase}.{targetTable.FullName} ON");

            builder.AppendLine(statement);

            if (targetTable.HasIdentiyColumn)
                builder.AppendLine($"SET IDENTITY_INSERT {_dbSettings.TargetDatabase}.{targetTable.FullName} OFF");

            return builder.ToString();
        }

        public override string CreateInitialStatement(DbTable targetTable, string targetDb, string alias)
        {
            var builder = new StringBuilder();

            builder.AppendLine($"INSERT INTO {targetDb}.{targetTable.FullName} ({targetTable.Csv()})");
            builder.AppendLine($"SELECT {targetTable.Csv(alias)}");
            builder.AppendLine($"FROM {targetTable.FullName} {alias}");

            return builder.ToString();
        }
    }
}