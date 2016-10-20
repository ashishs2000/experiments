using SqlDb.Baseline.ConfigSections;

namespace SqlDb.Baseline.Models
{
    public class InnerJoin
    {
        private readonly IDatabaseConfig _config;
        public string LeftColumn { get; set; }
        public string LeftAlias { get; set; }

        public string RightTable { get; set; }
        public string RightColumn { get; set; }
        public string RightAlias { get; set; }

        public InnerJoin(IDatabaseConfig config)
        {
            _config = config;
        }

        public void LeftCondition(string leftColumn, string leftAlias)
        {
            LeftColumn = leftColumn;
            LeftAlias = leftAlias;
        }

        public void RightCondition(string rightTable, string rightColumn, string rightAlias)
        {
            RightTable = rightTable;
            RightColumn = rightColumn;
            RightAlias = rightAlias;
        }

        public override string ToString()
        {
            return $"INNER JOIN {_config.SourceDatabase}.{RightTable} {RightAlias} ON {RightAlias}.{RightColumn} = {LeftAlias}.{LeftColumn}";
        }
    }

    public class EmployerJoin : InnerJoin
    {
        public EmployerJoin(IDatabaseConfig config, string leftAlias) 
            : base(config)
        {
            RightTable = "@EmployerIds";
            RightColumn = "EmployerId";
            LeftColumn = "EmployerId";
            LeftAlias = leftAlias;
            RightAlias = "eids";
        }
        
        public override string ToString()
        {
            return $"INNER JOIN {RightTable} {RightAlias} ON {RightAlias}.{RightColumn} = {LeftAlias}.{LeftColumn}";
        }
    }
}