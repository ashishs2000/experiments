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
            var tableName = $"{reader.GetString(0)}.{reader.GetString(1)}".ToLower();
            var columnName = reader.GetString(2);
            var primaryKey = reader.GetString(3);

            if (!Tables.ContainsKey(tableName))
                Tables.Add(tableName, new Table(tableName, primaryKey));

            Tables[tableName].Columns.Add(columnName);
        }

        public Table GetTable(string tableName)
        {
            return Tables[tableName.ToLower()];
        }
    }

    public class Table
    {
        public string Name { get; set; }
        public string PrimaryKey { get; set; }
        public IList<string> Columns { get; set; }

        public Table(string name, string primaryKey)
        {
            Name = name;
            PrimaryKey = primaryKey;
            Columns = new List<string>();
        }

        public override string ToString()
        {
            return $"{Name}({PrimaryKey})";
        }
    }

    public class TableRelationship
    {
        public string PrimaryKey { get; set; }
        public string PrimaryTable { get; set; }
        public string ForeignKey { get; set; }
        public string ForeignTable { get; set; }

        public override string ToString()
        {
            return $"{PrimaryTable} -> {ForeignTable}";
        }
    }


    #endregion

    #region Helpers

    public class Compare : IEqualityComparer<string>
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
                _trees.Add(table.Value.Name, new Tree(table.Value));
        }

        public void LoadRelations()
        {
            foreach (var relationship in _relations.Relationships)
            {
                var tree = _trees[relationship.ForeignTable.ToLower()];
                LoadRelation(tree, _relations);
            }
        }

        private void LoadRelation(Tree root, TableRelationshipQuery query)
        {
            foreach (var relationship in query.Relationships)
            {
                if (!relationship.ForeignTable.Equals(root.Node.Table.Name, StringComparison.OrdinalIgnoreCase))
                    continue;

                var tree = root.AddNode(_tables.GetTable(relationship.PrimaryTable), relationship.ForeignKey);
                if (tree == null)
                    continue;

                LoadRelation(tree, query);
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

            var print = new StringBuilder();
            foreach (var tree in database.TreeRelations)
                Print(1,tree.Value,print);

            var s = print.ToString();

            var g = database.TreeRelations["dbo.EvaluationRatingStepDetails".ToLower()];

            var counter = 1;
            var builder = new StringBuilder();
            builder.AppendLine($"Select * FROM {g.Node.Table.Name} a{counter}");
            var whereClause = new WhereBuilder();

            AppendJoin(builder, g, whereClause, ref counter);
            if(!string.IsNullOrEmpty(whereClause.Where))
            builder.AppendLine($"WHERE {whereClause.Where}");
            var x = builder.ToString();
        }

        private List<string> CreateSelectStatement(List<Tree> trees)
        {
            var selects = new List<string>();
            foreach (var tree in trees)
                selects.AddRange(CreateSelectStatement(tree));
            return selects;
        }

        private List<string> CreateSelectStatement(Tree tree)
        {
            var selects = new List<string>();

            const int counter = 1;
            var builder = new StringBuilder();
            builder.AppendLine($"Select * FROM {tree.Node.Table.Name} a{counter}");
            var whereClause = new WhereBuilder();


            return selects;
        }
        
        private void AppendJoin(StringBuilder builder, Tree tree, WhereBuilder whereClause, ref int counter)
        {
            if(!tree.Childrens.Any())
                return;

            foreach (var children in tree.Childrens)
            {
                var previousAlias = $"a{counter}";

                counter++;
                var nextAlias = $"a{counter}";
                builder.AppendLine(
                    $"JOIN {children.Node.Table.Name} {nextAlias} ON {nextAlias}.{children.Node.Table.PrimaryKey} = {previousAlias}.{children.ForeignKey}");

                if (children.Node.Table.Columns.Contains("employerId", new Compare()))
                    whereClause.Add($"{nextAlias}.EmployerId", "employers");
                AppendJoin(builder, children, whereClause, ref counter);
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

    public class WhereBuilder
    {
        private StringBuilder builder = new StringBuilder();

        public string Where => builder.ToString();
        public void Add(string column, string parameterName)
        {
            if (builder.Length > 0)
                builder.AppendLine(" AND ");

            builder.Append($"{column} = @{parameterName}");
        }
    }

    

    public class Node : IEquatable<Node>
    {
        public Table Table { get; private set; }
        public Node(Table table)
        {
            Table = table;
        }
        
        public bool Equals(Node other)
        {
            return Table.Name == other.Table.Name;
        }

        public override string ToString()
        {
            return $"{Table}";
        }
    }

    public class Tree
    {
        public Node Node { get; set; }
        public string ForeignKey { get; set; }
        public IList<Tree> Childrens { get; set; }

        public Tree(Table table)
        {
            var root = new Node(table);
            this.Node = root;
            Childrens = new List<Tree>();
        }

        public Tree AddNode(Table table, string foreignKey)
        {
            var tree = new Tree(table);
            if(IsNodeExists(Node, tree.Node))
                return null;

            tree.ForeignKey = foreignKey;
            Childrens.Add(tree);
            return tree;
        }

        private bool IsNodeExists(Node root, Node node)
        {
            if (root.Equals(node))
                return true;

            foreach (var children in Childrens)
            {
                if (children.Node != null && IsNodeExists(node,children.Node))
                    return true;
            }
            return false;
        }

        public override string ToString()
        {
            return string.IsNullOrEmpty(ForeignKey) ? $"{Node}"  : $"{Node} <<FK - {ForeignKey}>>";
        }
    }
}