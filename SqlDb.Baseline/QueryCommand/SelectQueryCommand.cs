using System.Text;
using SqlDb.Baseline.ConfigSections;
using SqlDb.Baseline.Models;

namespace SqlDb.Baseline.QueryCommand
{
    public class SelectQueryCommand : BaseQueryCommand
    {
        public sealed override SqlTemplate Template { get; set; }
        public override bool ShouldSkipCustomScripts { get; } = true;

        public SelectQueryCommand(IApplicationSetting appSettings)
            : base(appSettings)
        {
            Template = appSettings.SelectTemplate;
        }

        public override string SurroundStatement(DbTable targetTable, string statement)
        {
            return statement;
        }

        public override string CreateInitialStatement(IDatabaseConfig config, DbTable targetTable, string alias)
        {
            var builder = new StringBuilder();

            builder.AppendLine("SELECT count(1)");
            builder.AppendLine($"FROM {targetTable.FullName} {alias}");

            return builder.ToString();
        }
    }
}