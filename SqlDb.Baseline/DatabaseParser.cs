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
        private readonly TableRelationshipQuery _relations;

        public Dictionary<string, Tree> TreeRelations { get; } = new Dictionary<string, Tree>();
        public TableQuery Tables { get; }

        public int TablesCount => Tables.OnlyTables.Values.Count();
        private FileWriter EventLogger => _dbSettings.EventLogger;

        public DatabaseParser(TableQuery tables, TableRelationshipQuery relations, DatabaseElementConfiguration dbSettings)
        {
            this.Tables = tables;
            this._relations = relations;
            _dbSettings = dbSettings;

            foreach (var table in Tables.OnlyTables)
                TreeRelations.Add(table.Value.FullName, new Tree(table.Value));
        }

        public void LoadRelations()
        {
            EventLogger.AddHeader("Extracted Information");
            EventLogger.WriteLine($"    Total Tables : {Tables.OnlyTables.Count}");
            EventLogger.WriteLine($"    Total Mapped Relations : {_relations.Relationships.Count}");
            EventLogger.WriteLine($"    Total Custom Relations : {_dbSettings.TableToEmployerMappers.Count}");
            EventLogger.NewLine();

            AppendRelationWhichCanLinkToEmployer();

            foreach (var tree in TreeRelations.Values)
                CreateRelationalGraph(tree);
        }

        #region --- Private Methods ----
        
        private void CreateRelationalGraph(Tree target)
        {
            var relations = _relations.GetParentTables(target.Table.FullName);
            foreach (var relation in relations)
            {
                var rTable = Tables.GetTable(relation.PrimaryTable);
                var rTree = target.AddRelation(relation.PrimaryKey, rTable, relation.ForeignKey);
                if (rTree != null)
                    CreateRelationalGraph(rTree);
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
                if (!Tables.IsTableOrViewExists(mapper.Table))
                    continue;

                foreach (var table in Tables.OnlyTables.Values)
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