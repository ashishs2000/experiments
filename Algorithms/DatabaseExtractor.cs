using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using LibGit2Sharp;

namespace Algorithms
{
    public class DatabaseExtractor
    {
        public void Extract()
        {
            var tables = new TableQuery();
            var relations = new TableRelationshipQuery();
            var graph = new Graph(tables,relations);
            graph.Clean();
            graph.Generate();
        }
    }

    #region Models And Query

    public static class DatabaseReader
    {
        private static readonly string Connection = ConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;
        public static void Execute(string query, Action<SqlDataReader> extract)
        {
            using (var con = new SqlConnection(Connection))
            {
                var command = new SqlCommand(query, con);
                con.Open();

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    extract(reader);
                }
            }
        }
    }

    public class TableRelationshipQuery
    {
        private const string TABLE_QUERY = @"SELECT
                                            PK_Table = PK.TABLE_SCHEMA + '.' + PK.TABLE_NAME,
                                            PK_Column = PT.COLUMN_NAME,
                                            K_Table = Fk.TABLE_SCHEMA + '.' + FK.TABLE_NAME,
                                            FK_Column = CU.COLUMN_NAME
                                            FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS C
                                            INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS FK ON C.CONSTRAINT_NAME = FK.CONSTRAINT_NAME
                                            INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS PK ON C.UNIQUE_CONSTRAINT_NAME = PK.CONSTRAINT_NAME
                                            INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE CU ON C.CONSTRAINT_NAME = CU.CONSTRAINT_NAME
                                            INNER JOIN (
                                                SELECT i1.TABLE_NAME, i2.COLUMN_NAME
                                                FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS i1
                                                INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE i2 ON i1.CONSTRAINT_NAME = i2.CONSTRAINT_NAME
                                                WHERE i1.CONSTRAINT_TYPE = 'PRIMARY KEY'
                                            ) PT ON PT.TABLE_NAME = PK.TABLE_NAME
                                            WHERE FK.Table_NAME like '%Evaluation%'
                                            ORDER BY 3,1";

        public List<TableRelationship> Relationships { get; }
        public TableRelationshipQuery()
        {
            Relationships = new List<TableRelationship>();
            DatabaseReader.Execute(TABLE_QUERY, AddTableInfo);
        }

        private void AddTableInfo(SqlDataReader reader)
        {
            var relation = new TableRelationship
            {
                PrimaryTable = reader.GetString(0),
                PrimaryKey = reader.GetString(1),
                ForeignTable = reader.GetString(2),
                ForeignKey = reader.GetString(3)
            };
            Relationships.Add(relation);
        }

        public TableRelationship GetRelation(string primaryTable, string foerignTable)
        {
            return Relationships
                .FirstOrDefault(p => p.PrimaryTable.Equals(primaryTable, StringComparison.OrdinalIgnoreCase)
                                     && p.ForeignTable.Equals(foerignTable, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<TableRelationship> GetParentTables(string foreignTable)
        {
            return Relationships
                .Where(p => p.ForeignTable.Equals(foreignTable, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<TableRelationship> GetForeignTables(string primaryTable)
        {
            return Relationships
                .Where(p => p.PrimaryTable.Equals(primaryTable, StringComparison.OrdinalIgnoreCase));
        }
    }

    public class TableQuery
    {
        private const string TABLE_QUERY = @"SELECT col.TABLE_SCHEMA, col.TABLE_NAME, col.COLUMN_NAME, PT.COLUMN_NAME as [PrimaryKey]
                                            FROM INFORMATION_SCHEMA.COLUMNS col
                                            INNER JOIN (
                                                SELECT i1.TABLE_NAME, i2.COLUMN_NAME, i1.TABLE_SCHEMA
                                                FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS i1
                                                INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE i2 ON i1.CONSTRAINT_NAME = i2.CONSTRAINT_NAME
                                                WHERE i1.CONSTRAINT_TYPE = 'PRIMARY KEY'
                                            ) PT ON col.TABLE_NAME = PT.TABLE_NAME AND col.TABLE_SCHEMA = PT.TABLE_SCHEMA
                                            ORDER BY col.TABLE_NAME, ORDINAL_POSITION";

        public Dictionary<string, Table> Tables { get; private set; }
        public TableQuery()
        {
            Tables = new Dictionary<string, Table>();
            DatabaseReader.Execute(TABLE_QUERY, AddTableInfo);
        }

        private void AddTableInfo(SqlDataReader reader)
        {
            var schema = reader.GetString(0).ToLower();
            var table = reader.GetString(1).ToLower();
            var fullName = $"{schema}.{table}";
            var columnName = reader.GetString(2);
            var primaryKey = reader.GetString(3);

            if (!Tables.ContainsKey(fullName))
                Tables.Add(fullName, new Table(schema, table, primaryKey));

            Tables[fullName].Columns.Add(columnName);
        }

        public Table GetTable(string tableName)
        {
            return Tables[tableName.ToLower()];
        }
    }

    public class Table
    {
        public string FullName => $"{Schema}.{Name}";

        public string Schema { get; set; }
        public string Name { get; set; }
        public string PrimaryKey { get; set; }
        public IList<string> Columns { get; set; }
        public string Csv(string alias = null) => string.Join(",", string.IsNullOrEmpty(alias)
            ? Columns
            : Columns.Select(p => $"{alias}.{p}"));

        public Table(string schema,string name, string primaryKey)
        {
            Schema = schema;
            Name = name;
            PrimaryKey = primaryKey;
            Columns = new List<string>();
        }

        public TableRelationship FindAndGetRelationWithEmployer()
        {
            return Columns.Contains("userid", new IgnoreCaseComparer())
                ? TableRelationship.WithUser(FullName)
                : Columns.Contains("employeeid", new IgnoreCaseComparer())
                    ? TableRelationship.WithEmployee(FullName)
                    : null;
        }

        public bool HasEmployerId => Columns.Contains("employerid", new IgnoreCaseComparer());

        public override string ToString()
        {
            return $"{FullName}({PrimaryKey})";
        }
    }

    public class TableRelationship
    {
        public string PrimaryKey { get; set; }
        public string PrimaryTable { get; set; }
        public string ForeignKey { get; set; }
        public string ForeignTable { get; set; }

        public static TableRelationship WithUser(string foreignTable, string foreignKey = "UserId")
        {
            return new TableRelationship
            {
                PrimaryKey = "UserId",
                PrimaryTable = "dbo.EmployeePosition",
                ForeignKey = foreignKey,
                ForeignTable = foreignTable
            };
        }

        public static TableRelationship WithEmployee(string foreignTable, string foreignKey = "EmployeeId")
        {
            return new TableRelationship
            {
                PrimaryKey = "EmployeeId",
                PrimaryTable = "dbo.EmployeePosition",
                ForeignKey = foreignKey,
                ForeignTable = foreignTable
            };
        }

        public void AddMissingRelation(IList<Table> tables)
        {
            foreach (var table in tables)
            {
                
            }
        }

        public override string ToString()
        {
            return $"{PrimaryTable} -> {ForeignTable}";
        }
    }


    #endregion

    #region Helpers

    public class IgnoreCaseComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return x.Equals(y, StringComparison.CurrentCultureIgnoreCase);
        }

        public int GetHashCode(string obj)
        {
            return 0;
        }
    }

    #endregion


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
            foreach (var tree in _trees.Values)
            {
                Load(tree);
            }

            //foreach (var relationship in _relations.Relationships)
            //{
            //    var tree = _trees[relationship.ForeignTable.ToLower()];
            //    LoadRelation(tree);
            //}
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

        private void LoadRelation(Tree root)
        {
            foreach (var relationship in _relations.Relationships)
            {
                if (!relationship.ForeignTable.Equals(root.Table.FullName, StringComparison.OrdinalIgnoreCase))
                    continue;

                var tree = root.AddNode(_tables.GetTable(relationship.PrimaryTable), relationship.ForeignKey);
                if (tree == null)
                    continue;

                LoadRelation(tree);
            }
        }
    }

    public class Graph
    {
        private readonly TableQuery _tables;
        private readonly TableRelationshipQuery _relations;

        public Graph(TableQuery tables, TableRelationshipQuery relations)
        {
            this._tables = tables;
            this._relations = relations;
        }

        public void Generate()
        {
            var database = new Database(_tables, _relations);
            database.LoadRelations();

            var t  = new DatabaseTraversal();
            t.Start(database);

            var print = new StringBuilder();
            foreach (var tree in database.TreeRelations)
                Print(1,tree.Value,print);

            var s = print.ToString();

            var g = database.TreeRelations["dbo.EvaluationRatingStepDetails".ToLower()];
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

        private void Print(int tabIndex,Tree tree, StringBuilder builder)
        {
            builder.Append($"{"".PadRight(tabIndex)} {tree}");
            if (tree.Childrens.Any())
            {
                foreach (var children in tree.Childrens)
                    Print(tabIndex * 5, children, builder);
                return;
            }
            builder.AppendLine("--");
        }

        
    }

    public class DatabaseTraversal
    {
        private readonly StringBuilder _builder = new StringBuilder();
        private int _counter = 1;
        private int NextCounter => _counter = _counter + 1;
        private readonly Func<string, string, string> _insert = (table,columns) => $@"INSERT INTO  db.{table} ({columns})";

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

    //public class Node : IEquatable<Node>
    //{
    //    public Table Table { get; private set; }
    //    public Node(Table table)
    //    {
    //        Table = table;
    //    }
        
    //    public bool Equals(Node other)
    //    {
    //        return Table.Name == other.Table.Name;
    //    }

    //    public override string ToString()
    //    {
    //        return $"{Table}";
    //    }
    //}

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
            if(IsNodeExists(Table, tree.Table))
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
                if (children.Table != null && IsNodeExists(node,children.Table))
                    return true;
            }
            return false;
        }

        public override string ToString()
        {
            return string.IsNullOrEmpty(ForeignKey) ? $"{Table}"  : $"{Table} <<FK - {ForeignKey}>>";
        }
    }
}