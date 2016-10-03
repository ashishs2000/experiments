using System.Collections.Generic;

namespace SqlDb.Baseline.Models
{
    public class Tree
    {
        public Table Table { get; set; }
        public string ForeignKey { get; set; }
        public IList<Tree> Childrens { get; set; }

        public Tree(Table table)
        {
            var root = table;
            this.Table = root;
            Childrens = new List<Tree>();
        }

        public Tree AddNode(Table table, string foreignKey)
        {
            var tree = new Tree(table);
            if (IsNodeExists(Table, tree.Table))
                return null;

            tree.ForeignKey = foreignKey;
            Childrens.Add(tree);
            return tree;
        }

        private bool IsNodeExists(Table root, Table node)
        {
            if (root.Equals(node))
                return true;

            foreach (var children in Childrens)
            {
                if (children.Table != null && IsNodeExists(node, children.Table))
                    return true;
            }
            return false;
        }

        public override string ToString()
        {
            return string.IsNullOrEmpty(ForeignKey) ? $"{Table}" : $"{Table} <<FK - {ForeignKey}>>";
        }
    }
}