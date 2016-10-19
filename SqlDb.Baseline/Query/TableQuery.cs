using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using SqlDb.Baseline.ConfigSections;
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

        private const string VIEW_QUERY = @"
                                        SELECT v.TABLE_SCHEMA, v.TABLE_NAME, col.COLUMN_NAME
                                        FROM INFORMATION_SCHEMA.VIEWS v
                                        JOIN INFORMATION_SCHEMA.COLUMNS col on v.TABLE_SCHEMA = col.TABLE_SCHEMA AND v.TABLE_NAME = col.TABLE_NAME
                                        ORDER BY v.TABLE_SCHEMA, v.TABLE_NAME, col.ORDINAL_POSITION";

        private const string TABLE_IDENTITY = @"SELECT LOWER(sc.name + '.' + obj.name) AS TABLE_NAME
                                        FROM sys.columns col
                                        JOIN sys.objects obj ON col.object_id = obj.object_id
                                        JOIN sys.schemas sc ON sc.schema_id = obj.schema_id
                                        WHERE col.is_identity=1
                                        AND obj.type in (N'U')";

        private Dictionary<string, DbTable> _tables = null;

        public Dictionary<string, DbTable> AllObjects { get; } = new Dictionary<string, DbTable>();
        public IReadOnlyDictionary<string, DbTable> OnlyTables
        {
            get
            {
                if (_tables != null)
                    return _tables;

                return
                    _tables =
                        AllObjects.Where(p => p.Value.DbObjectType == DbObjectType.Table)
                            .ToDictionary(p => p.Key, p => p.Value);
            }
        }

        public TableQuery(DatabaseElementConfiguration configuration)
        {
            var conString = ConfigurationManager.ConnectionStrings[configuration.SourceDatabase].ConnectionString;

            var con = new SqlConnection(conString);
            con.Execute(TABLE_QUERY,AddTableInfo);
            SummaryRecorder.Current.TableCount = OnlyTables.Count;

            var con2 = new SqlConnection(conString);
            con2.Execute(VIEW_QUERY, AddViewInfo);
            SummaryRecorder.Current.ViewCount = AllObjects.Count - SummaryRecorder.Current.TableCount;

            var con3 = new SqlConnection(conString);
            con3.Execute(TABLE_IDENTITY, MapIdentityColumn);
        }

        private void AddTableInfo(SqlDataReader reader)
        {
            var schema = reader.GetString(0).ToLower();
            var table = reader.GetString(1).ToLower();
            var fullName = $"{schema}.{table}";
            var columnName = reader.GetString(2);
            var primaryKey = reader.GetString(3);

            if (!AllObjects.ContainsKey(fullName))
                AllObjects.Add(fullName, new DbTable(schema, table, primaryKey));

            if (AllObjects[fullName].DbObjectType == DbObjectType.Table && !AllObjects[fullName].Columns.Contains(columnName))
                AllObjects[fullName].Columns.Add(columnName);
        }

        private void AddViewInfo(SqlDataReader reader)
        {
            var schema = reader.GetString(0).ToLower();
            var table = reader.GetString(1).ToLower();
            var fullName = $"{schema}.{table}";
            var columnName = reader.GetString(2);

            if (!AllObjects.ContainsKey(fullName))
                AllObjects.Add(fullName, new DbView(schema, table));

            if (AllObjects[fullName].DbObjectType == DbObjectType.View)
                AllObjects[fullName].Columns.Add(columnName);
        }

        private void MapIdentityColumn(SqlDataReader reader)
        {
            var tablename = reader.GetString(0);
            if(!OnlyTables.ContainsKey(tablename))
                return;

            var table = OnlyTables[tablename];
            table.HasIdentiyColumn = true;
        }

        public bool IsTableOrViewExists(string tableName)
        {
            return AllObjects.ContainsKey(tableName.ToLower());
        }

        public DbTable GetTable(string tableName)
        {
            tableName = tableName.ToLower();
            return AllObjects.ContainsKey(tableName) ? AllObjects[tableName] : null;
        }
    }
}