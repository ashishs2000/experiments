using System.Text.RegularExpressions;

namespace SqlDb.Baseline.Models
{
    public class LinearTableView
    {
        public DbTable PrimaryTable { get; }
        public TableJoinCondition Next { get; private set; }

        public LinearTableView(DbTable primaryTable)
        {
            PrimaryTable = primaryTable;
        }

        public TableJoinCondition CreateNextRelation(string leftPrimaryKey, DbTable rightTable, string rightForeignKey)
        {
            return Next = new TableJoinCondition(leftPrimaryKey, rightForeignKey, new LinearTableView(rightTable));
        }
        
        public LinearTableView Copy() => Copy(this);
        
        public override string ToString()
        {
            return PrimaryTable.ToString();
        }

        public static bool CanLinkToEmployer(LinearTableView tableLink)
        {
            if (tableLink.PrimaryTable.CanBeAssociatedToEmployer)
                return true;

            return tableLink.Next != null && CanLinkToEmployer(tableLink.Next.RightForeignTable);
        }

        #region Private methods

        private bool Equals(DbTable other)
        {
            return Regex.IsMatch(PrimaryTable.FullName, other.FullName, RegexOptions.IgnoreCase);
        }

        private bool Equals(LinearTableView other)
        {
            return Regex.IsMatch(PrimaryTable.FullName, other.PrimaryTable.FullName, RegexOptions.IgnoreCase);
        }
        
        private LinearTableView Copy(LinearTableView current)
        {
            var link = new LinearTableView(current.PrimaryTable);
            if (current.Next != null)
                link.Next = Copy(current.Next);
            return link;
        }

        private TableJoinCondition Copy(TableJoinCondition current)
        {
            if (current?.RightForeignTable == null)
                return null;

            var rightForeignTable = Copy(current.RightForeignTable);
            var link = new TableJoinCondition(current.LeftPrimaryTableKey, current.RightForeignTableKey, rightForeignTable);
            return link;
        }

        #endregion
    }
}