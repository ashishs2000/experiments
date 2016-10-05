using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using SqlDb.Baseline.Helpers;

namespace SqlDb.Baseline.Models
{
    public class DbTable
    {
        public string FullName => $"{Schema}.{Name}";
        public virtual DbObjectType DbObjectType => DbObjectType.Table;

        public string Schema { get; set; }
        public string Name { get; set; }
        public string PrimaryKey { get; set; }
        public IList<string> Columns { get; set; }
        public string Csv(string alias = null) => string.Join(",", string.IsNullOrEmpty(alias)
            ? Columns
            : Columns.Select(p => $"{alias}.{p}"));

        public DbTable(string schema, string name, string primaryKey)
        {
            Schema = schema;
            Name = name;
            PrimaryKey = primaryKey;
            Columns = new List<string>();
        }
        
        public bool HasEmployerId => Columns.Contains("employerid", new IgnoreCaseComparer());
        public bool IsTableName(string tableName) => FullName.Equals(tableName, StringComparison.CurrentCultureIgnoreCase);
        public bool HasColumn(string columnName) => Columns.Contains(columnName, new IgnoreCaseComparer());

        private bool? _canAssociateToEmployer;
        public bool CanBeAssociatedToEmployer
        {
            get
            {
                if (_canAssociateToEmployer.HasValue)
                    return _canAssociateToEmployer.Value;

                _canAssociateToEmployer =
                    Columns.Any(column => Regex.IsMatch(column, ".*(employeeid|userid|employerid).*", RegexOptions.IgnoreCase));
                return _canAssociateToEmployer.Value;
            }
        }

        public override string ToString()
        {
            return $"{FullName}({PrimaryKey})";
        }
    }

    public class DbView : DbTable
    {
        public override DbObjectType DbObjectType => DbObjectType.View;
        public DbView(string schema, string name) 
            : base(schema, name, null)
        {

        }
    }

    public enum DbObjectType
    {
        Table,
        View
    }
}