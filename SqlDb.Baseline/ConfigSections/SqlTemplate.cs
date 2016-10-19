using SqlDb.Baseline.Models;

namespace SqlDb.Baseline.ConfigSections
{
    public class SqlTemplate
    {
        private readonly string _before;

        public string Statement { get; }
        public string After { get; }

        public SqlTemplate(string before, string statement, string after)
        {
            _before = before;
            Statement = string.IsNullOrEmpty(statement) ? "@statement" : statement;
            After = after;
        }

        public string Before(string database)
        {
            return _before.Replace("@database", database);
        }

        public string ToString(int counter, DbTable table, string statement)
        {
            var temp = Statement.Replace("@counter", counter.ToString());
            temp = temp.Replace("@tablename", table.FullName);
            temp = temp.Replace("@statement", statement);
            return temp;
        }
    }
}