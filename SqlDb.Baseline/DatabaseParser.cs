using System.Collections.Generic;
using System.Linq;
using SqlDb.Baseline.Configurations;
using SqlDb.Baseline.Helpers;
using SqlDb.Baseline.Models;
using SqlDb.Baseline.Query;

namespace SqlDb.Baseline
{
    public class DatabaseParser
    {
        private readonly DatabaseElementConfiguration _dbSettings;
        private readonly Dictionary<string, Tree> _trees = new Dictionary<string, Tree>();
        private readonly TableQuery _tables;
        private readonly TableRelationshipQuery _relations;
        private readonly IApplicationSetting _appSetting;
        private readonly IList<LinearTableView> _links = new List<LinearTableView>();

        public Dictionary<string, Tree> TreeRelations => _trees;
        public IEnumerable<LinearTableView> TableLinks => _links;
        public TableQuery Tables => _tables;
        public int TablesCount => _tables.OnlyTables.Values.Count();
        private FileWriter EventLogger => _dbSettings.EventLogger;

        public DatabaseParser(TableQuery tables, TableRelationshipQuery relations, IApplicationSetting appSetting, DatabaseElementConfiguration dbSettings)
        {
            this._tables = tables;
            this._relations = relations;
            _appSetting = appSetting;
            _dbSettings = dbSettings;

            foreach (var table in _tables.OnlyTables)
                _trees.Add(table.Value.FullName, new Tree(table.Value));
        }

        public void LoadRelations()
        {
            EventLogger.AddHeader("Extracted Information");
            EventLogger.WriteLine($"    Total Tables : {_tables.OnlyTables.Count}");
            EventLogger.WriteLine($"    Total Mapped Relations : {_relations.Relationships.Count}");
            EventLogger.WriteLine($"    Total Custom Relations : {_dbSettings.TableToEmployerMappers.Count}");
            EventLogger.NewLine();

            AppendRelationWhichCanLinkToEmployer();

            foreach (var tree in _trees.Values)
                CreateRelationalGraph(tree);

            ConvertRelationGraphToLinearRelations();
        }

        #region --- Private Methods ----
        
        private void CreateRelationalGraph(Tree target)
        {
            var relations = _relations.GetParentTables(target.Table.FullName);
            foreach (var relation in relations)
            {
                var rTable = _tables.GetTable(relation.PrimaryTable);
                var rTree = target.AddRelation(relation.PrimaryKey, rTable, relation.ForeignKey);
                if (rTree != null)
                    CreateRelationalGraph(rTree);
            }
        }

        private void ConvertRelationGraphToLinearRelations()
        {
            foreach (var primaryTree in TreeRelations.Values)
            {
                var link = new LinearTableView(primaryTree.Table);
                AlignToNextLink(link, link, primaryTree);
            }
        }

        private void AlignToNextLink(LinearTableView root, LinearTableView current, Tree tree)
        {
            if (tree.Childrens.Any())
            {
                foreach (var children in tree.Childrens)
                {
                    var next = current.CreateNextRelation(children.LeftKey, children.RightTree.Table, children.RightKey);
                    AlignToNextLink(root, next.RightForeignTable, children.RightTree);
                }
            }
            else
            {
                var link = root.Copy();
                _links.Add(link);
            }
        }

        private void AppendRelationWhichCanLinkToEmployer()
        {
            PrintSqlRelationStats();

            var counter = 0;
            var foundRelation = false;
            EventLogger.AddHeader("Following custom relationship are established");
            foreach (var mapper in _dbSettings.TableToEmployerMappers)
            {
                if (!_tables.IsTableOrViewExists(mapper.Table))
                    continue;

                foreach (var table in _tables.OnlyTables.Values)
                {
                    if (table.IsTableName(mapper.Table) || !table.HasColumn(mapper.Column))
                        continue;

                    counter++;
                    EventLogger.WriteLine($"    {counter}. '{table.FullName}' and '{mapper.Table}'");
                    _relations.AddNewRelation(mapper.Table, mapper.Column, table.FullName, mapper.Column);
                    foundRelation = true;
                }
            }

            if(!foundRelation)
                EventLogger.WriteLine("     No relation found");
            EventLogger.NewLine();
        }

        private void PrintSqlRelationStats()
        {
            EventLogger.AddHeader($"Following relationship exists in '{_dbSettings.Name}'");
            if (_relations.Relationships.Any())
            {
                var counter = 0;
                foreach (var relation in _relations.Relationships)
                {
                    counter++;
                    EventLogger.WriteLine($"    {counter}. '{relation.PrimaryTable}' and '{relation.ForeignTable}'");
                }
            }
            else
            {
                EventLogger.WriteLine("     No relationship exists.");
            }
            EventLogger.NewLine();
        }

        #endregion
    }
}