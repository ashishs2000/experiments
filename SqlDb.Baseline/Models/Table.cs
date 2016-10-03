using System.Collections.Generic;
using System.Linq;
using SqlDb.Baseline.Helpers;

namespace SqlDb.Baseline.Models
{
    public class Table
    {
        public string FullName => $"{Schema}.{Name}";

        public string Schema { get; set; }
        public string Name { get; set; }
        public string PrimaryKey { get; set; }
        public IList<string> Columns { get; set; }
        public string Csv(string alias = null) => string.Join(",", string.IsNullOrEmpty(alias)
            ? Columns
            : Columns.Select(p => $"{alias}.{p}"));

        public Table(string schema, string name, string primaryKey)
        {
            Schema = schema;
            Name = name;
            PrimaryKey = primaryKey;
            Columns = new List<string>();
        }

        public TableRelationship FindAndGetRelationWithEmployer()
        {
            return Columns.Contains("userid", new IgnoreCaseComparer())
                ? TableRelationship.WithUser(FullName)
                : Columns.Contains("employeeid", new IgnoreCaseComparer())
                    ? TableRelationship.WithEmployee(FullName)
                    : null;
        }

        public bool HasEmployerId => Columns.Contains("employerid", new IgnoreCaseComparer());

        public override string ToString()
        {
            return $"{FullName}({PrimaryKey})";
        }
    }
}