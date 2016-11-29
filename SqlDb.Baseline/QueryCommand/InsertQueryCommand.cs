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
            : base()
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

            builder.AppendLine(statement.Trim());

            if (targetTable.HasIdentiyColumn)
                builder.AppendLine($"SET IDENTITY_INSERT {_dbSettings.TargetDatabase}.{targetTable.FullName} OFF");

            return builder.ToString();
        }

        public override string CreateInitialStatement(IDatabaseConfig config, DbTable targetTable, string alias)
        {
            var builder = new StringBuilder();

            builder.AppendLine($"INSERT INTO {config.TargetDatabase}.{targetTable.FullName} ({targetTable.Csv()})");
            builder.AppendLine($"SELECT {targetTable.Csv(alias)}");
            builder.AppendLine($"FROM {config.SourceDatabase}.{targetTable.FullName} {alias}");

            return builder.ToString();
        }
    }
}