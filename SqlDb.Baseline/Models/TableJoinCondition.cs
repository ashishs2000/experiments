namespace SqlDb.Baseline.Models
{
    public class TableJoinCondition
    {
        public string LeftPrimaryTableKey { get; private set; }
        public string RightForeignTableKey { get; private set; }
        public LinearTableView RightForeignTable { get; set; }

        public TableJoinCondition(string leftPrimaryTableKey, string rightForeignTableKey, LinearTableView rightForeignTable)
        {
            LeftPrimaryTableKey = leftPrimaryTableKey;
            RightForeignTableKey = rightForeignTableKey;
            RightForeignTable = rightForeignTable;
        }
    }
}