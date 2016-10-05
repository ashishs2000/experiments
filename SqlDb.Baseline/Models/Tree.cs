using System.Collections.Generic;

namespace SqlDb.Baseline.Models
{
    public class NodeRelation
    {
        public string LeftKey { get; private set; }
        public string RightKey { get; private set; }
        public Tree RightTree { get; private set; }

        public NodeRelation(string leftKey, string rightKey, Tree rightTree)
        {
            LeftKey = leftKey;
            RightKey = rightKey;
            RightTree = rightTree;
        }

        public override string ToString()
        {
            return $"[{LeftKey} = {RightKey}({RightTree.Table.FullName})]";
        }
    }
    public class Tree
    {
        public DbTable Table { get; set; }
        public IList<NodeRelation> Childrens { get; set; }

        public Tree(DbTable table)
        {
            Table = table;
            Childrens = new List<NodeRelation>();
        }

        public Tree AddRelation(string leftKey, DbTable rightTable, string rightKey)
        {
            var tree = new Tree(rightTable);
            if (IsNodeExists(Table, tree.Table))
                return null;

            var relation = new NodeRelation(leftKey, rightKey, tree);
            Childrens.Add(relation);
            return tree;
        }

        private bool IsNodeExists(DbTable root, DbTable node)
        {
            if (root.Equals(node))
                return true;

            foreach (var children in Childrens)
            {
                if (children.RightTree.Table != null && IsNodeExists(node, children.RightTree.Table))
                    return true;
            }
            return false;
        }

        public override string ToString()
        {
            return Table.ToString();
        }
    }
}