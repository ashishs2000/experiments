using SqlDb.Baseline.Models;

namespace SqlDb.Baseline.ConfigSections
{
    public class SqlTemplate
    {
        public string Before { get; set; }
        public string Statement { get; set; } = "@statement";
        public string After { get; set; }

        public string ToString(DbTable table, string statement)
        {
            var temp = Statement.Replace("@tablename", table.FullName);
            temp = temp.Replace("@statement", statement);
            return temp;
        }
    }
}