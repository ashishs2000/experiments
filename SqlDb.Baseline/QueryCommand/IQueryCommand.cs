using SqlDb.Baseline.ConfigSections;
using SqlDb.Baseline.Models;

namespace SqlDb.Baseline.QueryCommand
{
    public interface IQueryCommand
    {
        string CreateInitialStatement(IDatabaseConfig databaseConfig, DbTable targetTable, string alias);

        string InjectQuery(int counter, DbTable table, string statement);

        SqlTemplate Template { get; }
        bool ShouldMigrateLookupTable { get; }
        bool ShouldMigrateTransactionTable { get; }
    }
}