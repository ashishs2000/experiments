using System.Collections.Generic;

namespace SqlDb.Baseline.Models
{
    public class TableRelationship
    {
        public string PrimaryKey { get; set; }
        public string PrimaryTable { get; set; }
        public string ForeignKey { get; set; }
        public string ForeignTable { get; set; }

        public static TableRelationship WithUser(string foreignTable, string foreignKey = "UserId")
        {
            return new TableRelationship
            {
                PrimaryKey = "UserId",
                PrimaryTable = "dbo.EmployeePosition",
                ForeignKey = foreignKey,
                ForeignTable = foreignTable
            };
        }

        public static TableRelationship WithEmployee(string foreignTable, string foreignKey = "EmployeeId")
        {
            return new TableRelationship
            {
                PrimaryKey = "EmployeeId",
                PrimaryTable = "dbo.EmployeePosition",
                ForeignKey = foreignKey,
                ForeignTable = foreignTable
            };
        }

        public void AddMissingRelation(IList<Table> tables)
        {
            foreach (var table in tables)
            {

            }
        }

        public override string ToString()
        {
            return $"{PrimaryTable} -> {ForeignTable}";
        }
    }
}