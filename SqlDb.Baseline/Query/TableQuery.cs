using System.Collections.Generic;
using System.Data.SqlClient;
using SqlDb.Baseline.Helpers;
using SqlDb.Baseline.Models;

namespace SqlDb.Baseline.Query
{
    public class TableQuery
    {
        private const string TABLE_QUERY = @"SELECT col.TABLE_SCHEMA, col.TABLE_NAME, col.COLUMN_NAME, PT.COLUMN_NAME as [PrimaryKey]
                                            FROM INFORMATION_SCHEMA.COLUMNS col
                                            INNER JOIN (
                                                SELECT i1.TABLE_NAME, i2.COLUMN_NAME, i1.TABLE_SCHEMA
                                                FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS i1
                                                INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE i2 ON i1.CONSTRAINT_NAME = i2.CONSTRAINT_NAME
                                                WHERE i1.CONSTRAINT_TYPE = 'PRIMARY KEY'
                                            ) PT ON col.TABLE_NAME = PT.TABLE_NAME AND col.TABLE_SCHEMA = PT.TABLE_SCHEMA
                                            ORDER BY col.TABLE_NAME, ORDINAL_POSITION";

        public Dictionary<string, DbTable> Tables { get; }
        public TableQuery(ConfigurationSetting setting)
        {
            Tables = new Dictionary<string, DbTable>();
            DatabaseReader.Execute(TABLE_QUERY, AddTableInfo);

            setting.LogFileWriter.WriteLine($"Total Tables Found: {Tables.Count}");
        }

        private void AddTableInfo(SqlDataReader reader)
        {
            var schema = reader.GetString(0).ToLower();
            var table = reader.GetString(1).ToLower();
            var fullName = $"{schema}.{table}";
            var columnName = reader.GetString(2);
            var primaryKey = reader.GetString(3);

            if (!Tables.ContainsKey(fullName))
                Tables.Add(fullName, new DbTable(schema, table, primaryKey));

            Tables[fullName].Columns.Add(columnName);
        }

        public bool IsTableExists(string tableName)
        {
            return Tables.ContainsKey(tableName.ToLower());
        }

        public DbTable GetTable(string tableName)
        {
            return Tables[tableName.ToLower()];
        }
    }
}