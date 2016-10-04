using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using SqlDb.Baseline.Helpers;
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

                var setting = new ConfigurationSetting(tables, relations);

                var database = new Database(tables, relations);
                database.LoadRelations();

                var query = new QueryGenerator(database);
                query.Create();
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
        private readonly IList<TableLink> _links = new List<TableLink>();

        public Dictionary<string, Tree> TreeRelations => _trees;
        public IEnumerable<TableLink> TableLinks => _links;
        public TableQuery Tables => _tables;
        public int TablesCount => _tables.Tables.Values.Count;

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
                Load(tree);
            CreateTableLinks();
        }

        private void CreateTableLinks()
        {
            foreach (var primaryTree in TreeRelations.Values)
            {
                //if(primaryTree.Table.Name != "evaluationratingstepdetails")
                //    continue;
                var link = new TableLink(primaryTree.Table, primaryTree.ForeignKey);
                Traverse(link, link, primaryTree);
            }

            var builder = new StringBuilder();
            foreach (var link in _links)
            {
                builder.AppendLine(link.Print());
            }
        }

        private void Traverse(TableLink root, TableLink current, Tree tree)
        {
            if (tree.Childrens.Any())
            {
                foreach (var children in tree.Childrens)
                {
                    var next = current.AddNextLink(children.Table, children.ForeignKey);
                    Traverse(root, next, children);
                }
            }
            else
            {
                var link = root.Copy();
                _links.Add(link);
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

        private void Clean()
        {
            foreach (var table in _tables.Tables.Values)
            {
                var relation = table.FindAndGetRelationWithEmployer();
                if (relation == null)
                    continue;
                _relations.Relationships.RemoveAll(p => p.PrimaryTable.Equals(table.FullName));
                _relations.Relationships.Add(relation);
            }
        }
    }
    
    public class TableLink
    {
        public Table PrimaryTable { get; }
        public string ForeignKey { get; }
        public TableLink Next { get; private set; }

        public TableLink(Table primaryTable, string foreignKey)
        {
            PrimaryTable = primaryTable;
            ForeignKey = foreignKey;
        }

        public TableLink AddNextLink(Table table, string foreignKey)
        {
            return Next = new TableLink(table, foreignKey);
        }
        
        public TableLink Copy() => Copy(this);
        
        public string Print()
        {
            var builder = new StringBuilder();
            Print(this, builder);
            return builder.ToString();
        }

        public override string ToString()
        {
            return string.IsNullOrEmpty(ForeignKey) ? $"{PrimaryTable}" : $"{PrimaryTable}<<{ForeignKey}>>";
        }

        public static bool CanLinkToEmployer(TableLink tableLink)
        {
            if (tableLink.PrimaryTable.CanBeAssociatedToEmployer)
                return true;

            return tableLink.Next != null && CanLinkToEmployer(tableLink.Next);
        }

        #region Private methods

        private bool Equals(Table other)
        {
            return Regex.IsMatch(PrimaryTable.FullName, other.FullName, RegexOptions.IgnoreCase);
        }

        private bool Equals(TableLink other)
        {
            return Regex.IsMatch(PrimaryTable.FullName, other.PrimaryTable.FullName, RegexOptions.IgnoreCase);
        }

        private void Print(TableLink current, StringBuilder builder)
        {
            builder.Append(current);
            if (current.Next != null)
            {
                builder.Append(" --> ");
                Print(current.Next, builder);
            }
        }

        private TableLink Copy(TableLink current)
        {
            var link = new TableLink(current.PrimaryTable, current.ForeignKey);
            if (current.Next != null)
                link.Next = Copy(current.Next);
            return link;
        }

        #endregion
    }

    public class ConfigurationSetting
    {
        private readonly Dictionary<string,string> _mappers = new Dictionary<string, string>(); 
        private readonly Dictionary<string,Func<string,string>> _joinMappers = new Dictionary<string, Func<string, string>>(); 
        public ConfigurationSetting(TableQuery tables,TableRelationshipQuery relations)
        {
            _mappers.Add("dbo.Goals","GoalId");
            _mappers.Add("dbo.Competencies", "CompetencyID");
            _mappers.Add("dbo.CompetencyGroups", "CompetencyGroupID");
            _mappers.Add("dbo.Trainings", "TrainingID");
            _mappers.Add("dbo.NeogovTasks", "TaskID");
            _mappers.Add("dbo.Programs", "ProgramID");

            _joinMappers.Add("ClassSpecificationID", alias => $"INNER JOIN ClassSpecifications c ON c.ClassSpecificationID = {alias}.ClassSpecificationID");
            foreach (var mapper in _mappers)
            {
                if(!tables.IsTableExists(mapper.Key))
                    continue;

                foreach (var table in tables.Tables.Values)
                {
                    if(table.IsTableName(mapper.Key) || !table.HasColumn(mapper.Value))
                        continue;

                    relations.AddNewRelation(mapper.Key,mapper.Value, table.FullName, mapper.Value);
                }
            }

        }
    }

    public class QueryGenerator
    {
        private readonly Database _database;
        private int _counter = 1;
        private int NextCounter => _counter = _counter + 1;

        private IList<string> _copyTableAsIt = new List<string>
        {
            "configuration.actionitems",
            "configuration.eventtype",
            "configuration.menu",
        };
        private readonly Func<Table,string,string> _tableTemplate = (table, statement) => $@"
IF NOT EXISTS (SELECT 1 FROM Migrations.Baseline WHERE TableName = '{table.FullName}')
BEGIN
	TRUNCATE TABLE {table.FullName}

	{statement}
	INSERT INTO Migrations.Baseline(TableName,IsCompleted)
	SELECT '{table.FullName}',1
END";
        public static string TargetDatabase { get; set; }

        public QueryGenerator(Database database)
        {
            _database = database;
            TargetDatabase = "test";
        }
         
        public void Create()
        {
            var builder = new StringBuilder();
            var missing = new List<TableLink>();
            var tableCounter = 1;
            foreach (var tableLink in _database.TableLinks)
            {
                if (!TableLink.CanLinkToEmployer(tableLink))
                {
                    missing.Add(tableLink);
                    continue;
                }
                _counter = 1;

                var statement = CreateInsertQuery(tableLink);
                statement = InjectQuery(tableCounter, tableLink.PrimaryTable, statement);
                builder.Append(statement);

                tableCounter++;
            }

            tableCounter = 1;
            builder.AppendLine("".PadRight(50, '-'));
            builder.AppendLine("-- Table Copied As it");
            builder.AppendLine("".PadRight(50, '-'));

            foreach (var tableName in _copyTableAsIt)
            {
                var table = _database.Tables.GetTable(tableName);
                var statement  = CreateInsert(table, TargetDatabase, "a");
                statement = InjectQuery(tableCounter, table, statement);
                builder.Append(statement);

                missing.RemoveAll(p => p.PrimaryTable.FullName == table.FullName);

                tableCounter++;
            }

            builder.AppendLine($"/*Missing Mapping - {missing.Count}/{_database.TablesCount}");
            foreach (var tableLink in missing.OrderBy(p=> p.PrimaryTable.Schema).ThenBy(p=>p.PrimaryTable.Name))
                builder.AppendLine($"   {tableLink.PrimaryTable.FullName} - ({tableLink.PrimaryTable.Csv()})");
            builder.AppendLine("*/");
            var query = builder.ToString();
       }

        private string InjectQuery(int counter, Table table, string statement)
        {
            var builder = new StringBuilder();
            builder.AppendLine($"-- ***** [{counter}] Migrating {table.FullName} ***** ");
            
            builder.AppendLine(_tableTemplate(table,statement));

            builder.AppendLine("".PadRight(50, '-'));
            builder.AppendLine("");
            return builder.ToString();
        }

        private string CreateInsertQuery(TableLink tableLink)
        {
            var pAlias = $"a{NextCounter}";
            var queryBuilder = new StringBuilder();
            queryBuilder.Append(CreateInsert(tableLink.PrimaryTable, TargetDatabase, pAlias));
            Join(tableLink, queryBuilder);

            return queryBuilder.ToString();
        }

        private void Join(TableLink tableLink, StringBuilder queryBuilder)
        {
            var pAlias = $"a{_counter}";
            if (tableLink.PrimaryTable.HasEmployerId)
            {
                queryBuilder.AppendLine(JoinEmployers(pAlias));
                return;
            }

            if (tableLink.Next == null)
                return;

            var cAlias = $"a{NextCounter}";
            queryBuilder.AppendLine($"INNER JOIN {tableLink.Next.PrimaryTable.FullName} {cAlias} " +
                               $"ON {pAlias}.{tableLink.PrimaryTable.PrimaryKey} " +
                               $"= {cAlias}.{tableLink.Next.ForeignKey}");
            Join(tableLink.Next, queryBuilder);
        }


        private string JoinEmployers(string alias, string joinColumn = "employerId")
        {
            return $"INNER JOIN @EmployerIds eids ON eids.EmployerId = {alias}.{joinColumn}";
        }

        private string CreateInsert(Table targetTable, string targetDb, string alias)
        {
            var builder = new StringBuilder();
            builder.AppendLine($"INSERT INTO {targetDb}.{targetTable.FullName} ({targetTable.Csv()})");
            builder.AppendLine($"SELECT {targetTable.Csv(alias)}");
            builder.AppendLine($"FROM {targetTable.FullName} {alias}");
            return builder.ToString();
        }
    }
}
