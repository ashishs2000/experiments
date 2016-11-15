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
        private Dictionary<string, DbTable> _tables;

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

        public TableQuery(QueryScripts queryScripts, IDatabaseConfig configuration)
        {
            var conString = ConfigurationManager.ConnectionStrings[configuration.SourceDatabase].ConnectionString;

            var con = new SqlConnection(conString);
            con.Execute(queryScripts.TableQuery, AddTableInfo);
            SummaryRecorder.Current.TableCount = OnlyTables.Count;

            var con2 = new SqlConnection(conString);
            con2.Execute(queryScripts.ViewQuery, AddViewInfo);
            SummaryRecorder.Current.ViewCount = AllObjects.Count - SummaryRecorder.Current.TableCount;

            var con3 = new SqlConnection(conString);
            con3.Execute(queryScripts.TableIdentityQuery, MapIdentityColumn);
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

        public bool IsView(string objectName)
        {
            objectName = objectName.ToLower();
            if (!AllObjects.ContainsKey(objectName))
                return false;

            return AllObjects[objectName].DbObjectType == DbObjectType.View;
        }

        public DbTable GetTable(string tableName)
        {
            tableName = tableName.ToLower();
            return AllObjects.ContainsKey(tableName) ? AllObjects[tableName] : null;
        }
    }
}