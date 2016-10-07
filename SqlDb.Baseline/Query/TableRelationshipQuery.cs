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
        private const string TABLE_QUERY = @"SELECT
                                            PK_Table = PK.TABLE_SCHEMA + '.' + PK.TABLE_NAME,
                                            PK_Column = PT.COLUMN_NAME,
                                            K_Table = Fk.TABLE_SCHEMA + '.' + FK.TABLE_NAME,
                                            FK_Column = CU.COLUMN_NAME
                                            FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS C
                                            INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS FK ON C.CONSTRAINT_NAME = FK.CONSTRAINT_NAME
                                            INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS PK ON C.UNIQUE_CONSTRAINT_NAME = PK.CONSTRAINT_NAME
                                            INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE CU ON C.CONSTRAINT_NAME = CU.CONSTRAINT_NAME
                                            INNER JOIN (
                                                SELECT i1.TABLE_NAME, i2.COLUMN_NAME
                                                FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS i1
                                                INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE i2 ON i1.CONSTRAINT_NAME = i2.CONSTRAINT_NAME
                                                WHERE i1.CONSTRAINT_TYPE = 'PRIMARY KEY'
                                            ) PT ON PT.TABLE_NAME = PK.TABLE_NAME
                                            WHERE FK.Table_NAME like '%Evaluation%'
                                            ORDER BY 3,1";

        public List<DbTableRelationship> Relationships { get; }
        public TableRelationshipQuery(DatabaseElementConfiguration configuration)
        {
            var conString = ConfigurationManager.ConnectionStrings[configuration.Name].ConnectionString;

            Relationships = new List<DbTableRelationship>();
            var con = new SqlConnection(conString);
            con.Execute(TABLE_QUERY, AddTableInfo);

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