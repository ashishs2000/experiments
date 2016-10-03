using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlDb.Baseline.Models;
using SqlDb.Baseline.Query;

namespace SqlDb.Baseline
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var tables = new TableQuery();
                var relations = new TableRelationshipQuery();

                var database = new Database(tables, relations);
                database.LoadRelations();

                var traversal = new DatabaseTraversal();
                traversal.Start(database);
            }
            catch(Exception ex)
            {
                Console.Out.WriteLine(ex.Message);
            }
        }
    }
    
    public class Database
    {
        private readonly Dictionary<string, Tree> _trees = new Dictionary<string, Tree>();
        private readonly TableQuery _tables;
        private readonly TableRelationshipQuery _relations;

        public Dictionary<string, Tree> TreeRelations => _trees;

        public Database(TableQuery tables, TableRelationshipQuery relations)
        {
            this._tables = tables;
            this._relations = relations;

            foreach (var table in _tables.Tables)
                _trees.Add(table.Value.FullName, new Tree(table.Value));
        }

        public void LoadRelations()
        {
            Clean();
            foreach (var tree in _trees.Values)
            {
                Load(tree);
            }
        }

        private void Load(Tree target)
        {
            var relations = _relations.GetParentTables(target.Table.FullName);
            foreach (var relation in relations)
            {
                var rTable = _tables.GetTable(relation.PrimaryTable);
                var rTree = target.AddNode(rTable, relation.ForeignKey);
                if (rTree != null)
                    Load(rTree);
            }
        }

        public void Clean()
        {
            foreach (var table in _tables.Tables.Values)
            {
                var relation = table.FindAndGetRelationWithEmployer();
                if (relation != null)
                {
                    var x = _relations.Relationships.Where(p => p.PrimaryTable.Equals(table.FullName));
                    _relations.Relationships.RemoveAll(p => p.PrimaryTable.Equals(table.FullName));
                    _relations.Relationships.Add(relation);
                }
            }
        }
    }
    

    public class DatabaseTraversal
    {
        private readonly StringBuilder _builder = new StringBuilder();
        private int _counter = 1;
        private int NextCounter => _counter = _counter + 1;
        private readonly Func<string, string, string> _insert = (table, columns) => $@"INSERT INTO  db.{table} ({columns})";

        public IList<string> CopyAsIsItTables { get; set; }

        public void Start(Database database)
        {
            foreach (var primaryTree in database.TreeRelations.Values)
            {
                var b = new StringBuilder();

                var pAlias = $"a{NextCounter}";
                b.AppendLine(_insert(primaryTree.Table.FullName, primaryTree.Table.Csv()));
                b.AppendLine($"SELECT {primaryTree.Table.Csv(pAlias)}");
                b.AppendLine($"FROM {primaryTree.Table.FullName} {pAlias}");
                Traverse(primaryTree, b);

                _builder.AppendLine(b.ToString());
                _counter = 1;
            }
            var x = _builder.ToString();
        }

        private void Traverse(Tree tree, StringBuilder rootQuery)
        {
            var pAlias = $"a{_counter}";
            if (tree.Table.HasEmployerId)
            {
                rootQuery.AppendLine($" {JoinEmployers(pAlias)}");
                return;
            }

            foreach (var children in tree.Childrens)
            {
                var cAlias = $"a{NextCounter}";
                var sql = $" INNER JOIN {children.Table.FullName} {cAlias}";
                sql = $"{sql} ON {pAlias}.{children.ForeignKey} = {cAlias}.{children.Table.PrimaryKey}\n";

                if (children.Table.HasEmployerId)
                {
                    sql = sql + " " + JoinEmployers(cAlias);
                    rootQuery.AppendLine(sql);
                    return;
                }
                else
                {
                    rootQuery.AppendLine(sql);
                    Traverse(children, rootQuery);
                }
            }
        }

        private string JoinEmployers(string alias, string joinColumn = "employerId")
        {
            return $" INNER JOIN @EmployerIds eids ON eids.EmployerId = {alias}.{joinColumn}";
        }
    }
}
