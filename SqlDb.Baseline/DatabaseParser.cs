using System;
using System.Collections.Generic;
using System.Linq;
using SqlDb.Baseline.ConfigSections;
using SqlDb.Baseline.Helpers;
using SqlDb.Baseline.Models;
using SqlDb.Baseline.Query;

namespace SqlDb.Baseline
{
    public class DatabaseParser
    {
        private readonly DatabaseElementConfiguration _dbSettings;

        public Dictionary<string, Tree> TreeRelations { get; } = new Dictionary<string, Tree>();
        public TableQuery Tables { get; }
        public TableRelationshipQuery TableRelations { get; }

        public int TablesCount => Tables.OnlyTables.Values.Count();

        public DatabaseParser(TableQuery tables, TableRelationshipQuery relations, DatabaseElementConfiguration dbSettings)
        {
            this.Tables = tables;
            this.TableRelations = relations;
            _dbSettings = dbSettings;

            foreach (var table in Tables.OnlyTables)
                TreeRelations.Add(table.Value.FullName, new Tree(table.Value));
        }

        public void LoadRelations()
        {
            AppendRelationWhichCanLinkToEmployer();

            foreach (var tree in TreeRelations.Values)
                CreateRelationalGraph(tree,tree, 1);
        }

        #region --- Private Methods ----
        
        private void CreateRelationalGraph(Tree root,Tree target, int level)
        {
            var relations = TableRelations.GetParentTables(target.Table.FullName);
            foreach (var relation in relations)
            {
                if (level > 10)
                    return;

                var rTable = Tables.GetTable(relation.PrimaryTable);
                var rTree = target.AddRelation(relation.PrimaryKey, rTable, relation.ForeignKey);
                if (rTree == null || rTable.HasEmployerId)
                    continue;

                level = level + 1;
                if (root.Height < level)
                    root.Height = level;

                CreateRelationalGraph(root,rTree, level);
            }
        }
          
        private void AppendRelationWhichCanLinkToEmployer()
        {
            ConsoleLogger.LogInfo("Searching possible relationships");
            ConsoleLogger.SetIndent();

            AddPossibleRelationships();
            PrintSqlRelationStats();

            var counter = 0;
            var foundRelations = 0;
            var iteratorCount = 0;

            LogFile.HeaderH3("Following custom relationship are established");

            decimal total = _dbSettings.TableToEmployerMappers.Count;
            var lastPercentReported = 0;

            Console.Out.Write("".PadRight(ConsoleLogger.CurrentIndent,' ') + "Percent completed - ");
            foreach (var mapper in _dbSettings.TableToEmployerMappers)
            {
                iteratorCount++;
                if (!Tables.IsTableOrViewExists(mapper.Table))
                    continue;

                foreach (var table in Tables.OnlyTables.Values)
                {
                    if (table.IsTableName(mapper.Table) || !table.HasColumn(mapper.Column))
                        continue;

                    counter++;
                    LogFile.Info($"    {counter}. '{table.FullName}' and '{mapper.Table}'");
                    if(TableRelations.AddNewRelation(mapper.Table, mapper.Column, table.FullName, mapper.Column,false))
                        foundRelations++;
                }

                var percentCompleted = Convert.ToInt32((iteratorCount/total)*100);
                if (lastPercentReported == percentCompleted || percentCompleted%20 != 0)
                    continue;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($" {percentCompleted}%  ");
                lastPercentReported = percentCompleted;
            }
            Console.ResetColor();
            Console.Out.WriteLine("");

            SummaryRecorder.Current.CustomDatabaseRelationCount = foundRelations;
            ConsoleLogger.LogInfo($"Total possible relationships found - {foundRelations}");
            if (foundRelations <= 0)
                LogFile.Info("     No relation found");

            ConsoleLogger.ResetIndent();
        }

        private void AddPossibleRelationships()
        {
            var counter = 0;
            foreach (var table in Tables.OnlyTables.Values)
            {
                if(table.PrimaryKey.Equals("id",StringComparison.CurrentCultureIgnoreCase))
                    continue;

                if (_dbSettings.TableToEmployerMappers.Any(p => p.Table == table.FullName && p.Column == table.PrimaryKey))
                    continue;

                counter = counter + 1;
                _dbSettings.TableToEmployerMappers.Add(new TableColumn(table.FullName,table.PrimaryKey));
            }
        }

        private void PrintSqlRelationStats()
        {
            LogFile.HeaderH3($"Following relationship exists in '{_dbSettings.SourceDatabase}'");
            if (TableRelations.Relationships.Any())
            {
                var counter = 0;
                foreach (var relation in TableRelations.Relationships)
                {
                    counter++;
                    LogFile.Info($"     {counter}. '{relation.PrimaryTable}' and '{relation.ForeignTable}'");
                }
            }
            else
            {
                LogFile.Info("      No relationship exists.");
            }
        }

        #endregion
    }
}