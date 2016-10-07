using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using SqlDb.Baseline.ConfigSections;
using SqlDb.Baseline.Helpers;
using SqlDb.Baseline.Models;

namespace SqlDb.Baseline
{
    public class BaselineScriptGenerator
    {
        private readonly DatabaseParser _databaseParser;
        private readonly IApplicationSetting _appSettings;
        private readonly DatabaseElementConfiguration _dbSettings;
        private readonly List<DbTable> _missing = new List<DbTable>();
        private readonly List<string> _tableCovered = new List<string>();
        private readonly List<string> _tableSkipped = new List<string>(); 

        private FileWriter ScriptWriter => _dbSettings.ScriptLogger;
        private FileWriter EventLogger => _dbSettings.EventLogger;

        public BaselineScriptGenerator(DatabaseParser databaseParser, IApplicationSetting appSettings, DatabaseElementConfiguration dbSettings)
        {
            _databaseParser = databaseParser;
            _appSettings = appSettings;
            _dbSettings = dbSettings;
        }

        public void Generate()
        {
            ScriptWriter.WriteLine($"Use {_dbSettings.Name}");
            ScriptWriter.WriteLine("GO");

            ScriptWriter.AddHeader("Before Base Script");
            ScriptWriter.WriteLine(_appSettings.OutputFileBeforeData);

            AppendLookupTableMigration();
            CreateInsertStatementWithTree();
            LogMissingFile();
            LogSkippedTables();

            ScriptWriter.AddHeader("After Base Script");
            ScriptWriter.WriteLine(_appSettings.OutputFileAfterData);
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

                var builder = new QueryBuilder(table);
                BuildInsertStatement(tree.Value, 1, builder, new List<InnerJoin>());

                if (!builder.HasMappedEmployer)
                {
                    _missing.Add(table);
                    continue;
                }

                var statement = builder.ToString();
                statement = InjectQuery(tableCounter, table, statement);
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
                if(children.RightTree == null)
                    continue;
                var cAlias = $"a{aliasCounter = aliasCounter + 1}";

                var innerJoin = new InnerJoin();
                innerJoin.LeftCondition(children.LeftKey, pAlias);
                innerJoin.RightCondition(children.RightTree.Table.FullName, children.RightKey, cAlias);

                joins.Add(innerJoin);
                BuildInsertStatement(children.RightTree, aliasCounter, queryBuilder, joins);

                joins.RemoveAt(joins.Count - 1);
            }
        }

        private void AppendLookupTableMigration()
        {
            var tableCounter = 1;
            ScriptWriter.AddHeader("Lookup Table Migrations");

            foreach (var tableName in _dbSettings.LookupTables)
            {
                if(ShouldSkipTable(tableName))
                    continue;
                
                var table = _databaseParser.Tables.GetTable(tableName);
                if(table == null)
                    continue;

                var statement = CreateInsert(table, _dbSettings.TargetDatabase, "a");
                statement = InjectQuery(tableCounter, table, statement);

                ScriptWriter.WriteLine(statement);
                _tableCovered.Add(table.FullName);

                tableCounter++;
            }
        }

        private string CreateInsert(DbTable targetTable, string targetDb, string alias, bool excludeInsert = false)
        {
            var builder = new StringBuilder();
            if (!excludeInsert)
                builder.AppendLine($"INSERT INTO {targetDb}.{targetTable.FullName} ({targetTable.Csv()})");
            builder.AppendLine($"SELECT {targetTable.Csv(alias)}");
            builder.AppendLine($"FROM {targetTable.FullName} {alias}");
            return builder.ToString();
        }

        private string InjectQuery(int counter, DbTable table, string statement)
        {
            var statementBuilder = new StringBuilder();
            if (table.HasIdentiyColumn)
                statementBuilder.AppendLine($"SET IDENTITY_INSERT {_dbSettings.TargetDatabase}.{table.FullName} ON");
            statementBuilder.AppendLine(statement);
            if (table.HasIdentiyColumn)
                statementBuilder.AppendLine($"SET IDENTITY_INSERT {_dbSettings.TargetDatabase}.{table.FullName} OFF");

            var builder = new StringBuilder();
            builder.AppendLine($"-- ***** [{counter}] Migrating {table.FullName} ***** ");
            builder.AppendLine(_appSettings.TableTemplate(table, statementBuilder.ToString()));
            builder.AppendLine("".PadRight(50, '-'));
            builder.AppendLine("");
            return builder.ToString();
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
            EventLogger.AddHeader($"Missing Table Migrations {_missing.Count}/{_databaseParser.TablesCount}");
            if (!_missing.Any())
            {
                EventLogger.WriteLine("--   Perfect!!! All tables are accounted for migration");
                return;
            }

            foreach (var tableLink in _missing.OrderBy(p => p.Schema).ThenBy(p => p.Name))
            {
                if (ShouldSkipTable(tableLink.FullName))
                    continue;

                EventLogger.WriteLine($"   {counter}. {tableLink.FullName} - ({tableLink.Csv()})");
                counter++;
            }
            EventLogger.NewLine();
        }

        private void LogSkippedTables()
        {
            EventLogger.AddHeader("Skipped Tables");
            if (!_missing.Any())
            {
                EventLogger.WriteLine("--   No Skip Tables");
                return;
            }

            for (var i = 0; i < _tableSkipped.Count; i++)
                EventLogger.WriteLine($"   {i+1}. {_tableSkipped[i]}");
            EventLogger.NewLine();
        }
    }
}