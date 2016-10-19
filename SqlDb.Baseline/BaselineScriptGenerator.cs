using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using SqlDb.Baseline.ConfigSections;
using SqlDb.Baseline.Helpers;
using SqlDb.Baseline.Models;
using SqlDb.Baseline.QueryCommand;

namespace SqlDb.Baseline
{
    public class BaselineScriptGenerator
    {
        private readonly DatabaseParser _databaseParser;
        private readonly DatabaseElementConfiguration _dbSettings;
        private readonly IQueryCommand _command;
        private readonly List<DbTable> _missing = new List<DbTable>();
        private readonly List<string> _tableCovered = new List<string>();
        private readonly List<string> _tableSkipped = new List<string>();

        private FileWriter ScriptWriter => _dbSettings.ScriptLogger;

        public BaselineScriptGenerator(DatabaseParser databaseParser, DatabaseElementConfiguration dbSettings, IQueryCommand command)
        {
            _databaseParser = databaseParser;
            _dbSettings = dbSettings;
            _command = command;
        }

        public void Generate()
        {
            ScriptWriter.WriteLine(_command.Template.Before(_dbSettings.Name));

            if (_command.ShouldMigrateLookupTable)
                AppendLookupTableMigration();

            if (_command.ShouldMigrateTransactionTable)
                CreateInsertStatementWithTree();

            LogMissingFile();
            LogSkippedTables();

            ScriptWriter.WriteLine(_command.Template.After);

            SummaryRecorder.Current.IgnoreTableCount = _missing.Count;
            SummaryRecorder.Current.MigrationTableCount = _tableCovered.Count;
        }

        private void CreateInsertStatementWithTree()
        {
            ScriptWriter.AddHeader("Transactional Table Migrations");
            var tableCounter = 1;
            foreach (var tree in _databaseParser.TreeRelations)
            {
                var table = tree.Value.Table;
                if (ShouldSkipTable(table.FullName))
                    continue;

                var builder = new QueryBuilder(table, _command);
                BuildInsertStatement(tree.Value, 1, builder, new List<InnerJoin>());

                if (!builder.HasMappedEmployer)
                {
                    _missing.Add(table);
                    continue;
                }

                var statement = builder.ToString();
                statement = _command.InjectQuery(tableCounter, table, statement);
                ScriptWriter.WriteLine(statement);

                _tableCovered.Add(table.FullName);
                tableCounter++;
            }
        }

        private void BuildInsertStatement(Tree joinTree, int aliasCounter, QueryBuilder queryBuilder, IList<InnerJoin> joins)
        {
            if(joinTree.Table == null)
                return;

            var pAlias = $"a{aliasCounter}";
            if (joinTree.Table.HasEmployerId)
            {
                queryBuilder.Add(pAlias, joins.ToArray());
                return;
            }

            if (!joinTree.Childrens.Any())
                return;

            foreach (var children in joinTree.Childrens)
            {
                if(children.RightTree == null || !joinTree.Table.HasColumn(children.LeftKey))
                    continue;

                var cAlias = $"a{aliasCounter = aliasCounter + 1}";

                var innerJoin = new InnerJoin();
                innerJoin.LeftCondition(children.LeftKey, pAlias);

                var rightKey = ResolveRightKey(children.RightKey,children.RightTree.Table);
                innerJoin.RightCondition(children.RightTree.Table.FullName, rightKey, cAlias);

                joins.Add(innerJoin);
                BuildInsertStatement(children.RightTree, aliasCounter, queryBuilder, joins);

                joins.RemoveAt(joins.Count - 1);
            }
        }

        private string ResolveRightKey(string rightKey, DbTable rightTable)
        {
            return rightTable.HasColumn(rightKey) ? rightKey : rightTable.PrimaryKey;
        }

        private void AppendLookupTableMigration()
        {
            var tableCounter = 1;
            var migrated = false;
            LogFile.HeaderH3("Lookup Table Migrations");

            foreach (var tableName in _dbSettings.LookupTables)
            {
                if(ShouldSkipTable(tableName))
                    continue;
                
                var table = _databaseParser.Tables.GetTable(tableName);
                if(table == null)
                    continue;

                var statement =  _command.CreateInitialStatement(table, _dbSettings.TargetDatabase, "a");
                statement = _command.InjectQuery(tableCounter, table, statement);

                ScriptWriter.WriteLine(statement);
                _tableCovered.Add(table.FullName);
                migrated = true;

                tableCounter++;
            }

            if (migrated)
                LogFile.Info("  No Lookup table found");
        }
        
        private bool ShouldSkipTable(string tablename)
        {
            if (_dbSettings.SkipTables.Any(p => Regex.IsMatch(tablename, p, RegexOptions.IgnoreCase)))
            {
                _tableSkipped.Add(tablename);
                return true;
            }

            if (_tableCovered.Contains(tablename, new IgnoreCaseComparer()))
                return true;

            return false;
        }

        private void LogMissingFile()
        {
            var counter = 1;
            LogFile.HeaderH3($"Missing Table Migrations {_missing.Count}/{_databaseParser.TablesCount}");
            if (!_missing.Any())
            {
                LogFile.Info("--   Perfect!!! All tables are accounted for migration");
                return;
            }

            foreach (var tableLink in _missing.OrderBy(p => p.Schema).ThenBy(p => p.Name))
            {
                if (ShouldSkipTable(tableLink.FullName))
                    continue;

                LogFile.Info($"   {counter}. {tableLink.FullName} - ({tableLink.Csv()})");
                counter++;
            }
        }

        private void LogSkippedTables()
        {
            LogFile.HeaderH3("Skipped Tables");
            if (!_missing.Any())
            {
                LogFile.Info("      No Skip Tables");
                return;
            }

            for (var i = 0; i < _tableSkipped.Count; i++)
                LogFile.Info($"   {i+1}. {_tableSkipped[i]}");
        }
    }
}