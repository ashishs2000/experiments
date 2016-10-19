using System.Text;
using SqlDb.Baseline.ConfigSections;
using SqlDb.Baseline.Models;

namespace SqlDb.Baseline.QueryCommand
{
    public abstract class BaseQueryCommand : IQueryCommand
    {
        private readonly IApplicationSetting _appSettings;
        
        public abstract string SurroundStatement(DbTable targetTable, string statement);
        public abstract string CreateInitialStatement(DbTable targetTable, string targetDb, string alias);

        public abstract SqlTemplate Template { get; set; }

        public bool ShouldMigrateLookupTable { get; } = true;
        public bool ShouldMigrateTransactionTable { get; } = true;

        protected BaseQueryCommand(IApplicationSetting appSettings)
        {
            _appSettings = appSettings;
        }

        public string InjectQuery(int counter, DbTable table, string statement)
        {
            var builder = new StringBuilder();

            statement = SurroundStatement(table, statement);
            builder.AppendLine(Template.ToString(counter,table, statement));

            return builder.ToString();
        }
    }
}