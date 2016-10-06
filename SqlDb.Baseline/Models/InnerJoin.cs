namespace SqlDb.Baseline.Models
{
    public class InnerJoin
    {
        public string LeftColumn { get; set; }
        public string LeftAlias { get; set; }

        public string RightTable { get; set; }
        public string RightColumn { get; set; }
        public string RightAlias { get; set; }

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
            return $"INNER JOIN {RightTable} {RightAlias} ON {RightAlias}.{RightColumn} = {LeftAlias}.{LeftColumn}";
        }
    }
}