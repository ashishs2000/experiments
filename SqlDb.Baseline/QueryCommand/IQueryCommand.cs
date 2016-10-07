using SqlDb.Baseline.Models;

namespace SqlDb.Baseline.QueryCommand
{
    public interface IQueryCommand
    {
        string BeforeTemplate { get; }
        string AfterTemplate { get; }
        string CreateQuery(DbTable targetTable, string targetDb, string alias, bool excludeInsert = false);
        string InjectQuery(int counter, DbTable table, string statement);

        bool ShouldMigrateLookupTable { get; }
        bool ShouldMigrateTransactionTable { get; }
    }
}