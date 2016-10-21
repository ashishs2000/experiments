using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using SqlDb.Baseline.ConfigSections;
using SqlDb.Baseline.Helpers;
using SqlDb.Baseline.Models;

namespace SqlDb.Baseline.Query
{
    public class TableRelationshipQuery
    {
        public List<DbTableRelationship> Relationships { get; }
        public TableRelationshipQuery(QueryScripts queryScripts, IDatabaseConfig configuration)
        {
            var conString = ConfigurationManager.ConnectionStrings[configuration.SourceDatabase].ConnectionString;

            Relationships = new List<DbTableRelationship>();
            var con = new SqlConnection(conString);
            con.Execute(queryScripts.TableRelationshipQuery, AddTableInfo);

            SummaryRecorder.Current.DatabaseRelationCount = Relationships.Count;
        }

        public bool AddNewRelation(string primaryTable, string primaryKey, string foreignTable, string foreignKey, bool isRealRelation)
        {
            if (Relationships.Any(p => p.PrimaryTable.Equals(primaryTable, StringComparison.CurrentCultureIgnoreCase)
                                       && p.ForeignTable.Equals(foreignTable, StringComparison.InvariantCultureIgnoreCase)))
                return false;

            var relation = new DbTableRelationship
            {
                PrimaryTable = primaryTable,
                PrimaryKey = primaryKey,
                ForeignTable = foreignTable,
                ForeignKey = foreignKey,
                IsExistingRelation = true
            };
            Relationships.Add(relation);
            return true;
        }

        private void AddTableInfo(SqlDataReader reader)
        {
            var relation = new DbTableRelationship
            {
                PrimaryTable = reader.GetString(0),
                PrimaryKey = reader.GetString(1),
                ForeignTable = reader.GetString(2),
                ForeignKey = reader.GetString(3)
            };
            Relationships.Add(relation);
        }

        public DbTableRelationship GetRelation(string primaryTable, string foerignTable)
        {
            return Relationships
                .FirstOrDefault(p => p.PrimaryTable.Equals(primaryTable, StringComparison.OrdinalIgnoreCase)
                                     && p.ForeignTable.Equals(foerignTable, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<DbTableRelationship> GetParentTables(string foreignTable)
        {
            return Relationships
                .Where(p => p.ForeignTable.Equals(foreignTable, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<DbTableRelationship> GetForeignTables(string primaryTable)
        {
            return Relationships
                .Where(p => p.PrimaryTable.Equals(primaryTable, StringComparison.OrdinalIgnoreCase));
        }
    }
}