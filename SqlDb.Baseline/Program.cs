using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using SqlDb.Baseline.Configurations;
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
                var myCustomSection = ProductsConfigurationSection.GetConfiguration();

                //var setting = new ConfigurationSetting();

                //var tables = new TableQuery(setting);
                //var relations = new TableRelationshipQuery(setting);

                //var database = new Database(tables, relations, setting);
                //database.LoadRelations();

                //var query = new BaselineScriptGenerator(database, setting);
                //query.Generate();
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
        private readonly ConfigurationSetting _settings;
        private readonly IList<LinearTableView> _links = new List<LinearTableView>();

        public Dictionary<string, Tree> TreeRelations => _trees;
        public IEnumerable<LinearTableView> TableLinks => _links;
        public TableQuery Tables => _tables;
        public int TablesCount => _tables.Tables.Values.Count;

        public Database(TableQuery tables, TableRelationshipQuery relations, ConfigurationSetting settings)
        {
            this._tables = tables;
            this._relations = relations;
            _settings = settings;

            foreach (var table in _tables.Tables)
                _trees.Add(table.Value.FullName, new Tree(table.Value));
        }

        public void LoadRelations()
        {
            RemoveRelationIfNotLinkToEmployer();
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

        private void RemoveRelationIfNotLinkToEmployer()
        {
            foreach (var table in _tables.Tables.Values)
            {
                var relation = table.CanBeLinkedToEmployer();
                if (relation == null)
                    continue;
                _relations.Relationships.RemoveAll(p => p.PrimaryTable.Equals(table.FullName));
                _relations.Relationships.Add(relation);
            }
        }

        private void AppendRelationWhichCanLinkToEmployer()
        {
            var counter = 0;
            _settings.LogFileWriter.WriteLine($"Total Custom Relations Found : {_settings.TableToEmployerMappers.Count}");

            foreach (var mapper in _settings.TableToEmployerMappers)
            {
                if (!_tables.IsTableExists(mapper.Key))
                    continue;

                foreach (var table in _tables.Tables.Values)
                {
                    if (table.IsTableName(mapper.Key) || !table.HasColumn(mapper.Value))
                        continue;

                    counter++;
                    _settings.LogFileWriter.WriteLine($"    {counter}. '{table.FullName}' and '{mapper.Key}'");
                    _relations.AddNewRelation(mapper.Key, mapper.Value, table.FullName, mapper.Value);
                }
            }
        }

        #endregion
    }
}
