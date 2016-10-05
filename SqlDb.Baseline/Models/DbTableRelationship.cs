using System.Collections.Generic;

namespace SqlDb.Baseline.Models
{
    public class DbTableRelationship
    {
        public string PrimaryKey { get; set; }
        public string PrimaryTable { get; set; }
        public string ForeignKey { get; set; }
        public string ForeignTable { get; set; }

        public static DbTableRelationship WithUser(string foreignTable, string foreignKey = "UserId")
        {
            return new DbTableRelationship
            {
                PrimaryKey = "UserId",
                PrimaryTable = "dbo.EmployeePosition",
                ForeignKey = foreignKey,
                ForeignTable = foreignTable
            };
        }

        public static DbTableRelationship WithEmployee(string foreignTable, string foreignKey = "EmployeeId")
        {
            return new DbTableRelationship
            {
                PrimaryKey = "EmployeeId",
                PrimaryTable = "dbo.EmployeePosition",
                ForeignKey = foreignKey,
                ForeignTable = foreignTable
            };
        }

        public override string ToString()
        {
            return $"{PrimaryTable} -> {ForeignTable}";
        }
    }
}