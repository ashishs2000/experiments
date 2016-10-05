using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using SqlDb.Baseline.Configurations;
using SqlDb.Baseline.Helpers;
using SqlDb.Baseline.Models;

namespace SqlDb.Baseline
{
    public class BaselineScriptGenerator
    {
        private readonly DatabaseParser _databaseParser;
        private readonly IApplicationSetting _appSettings;
        private readonly DatabaseElementConfiguration _dbSettings;
        private readonly List<LinearTableView> _missing = new List<LinearTableView>();
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
            var baseScript = File.ReadAllText("BeforeBaseline.sql");
            ScriptWriter.AddHeader("Base Script");
            ScriptWriter.WriteLine(baseScript);

            AppendLookupTableMigration();
            AppendTransactionTableMigration();
            LogMissingFile();
            LogSkippedTables();
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
                var statement = CreateInsert(table, _dbSettings.TargetDatabase, "a");
                statement = InjectQuery(tableCounter, table, statement);

                ScriptWriter.WriteLine(statement);
                _tableCovered.Add(table.FullName);

                tableCounter++;
            }
        }

        private void AppendTransactionTableMigration()
        {
            var tableCounter = 1;
            ScriptWriter.AddHeader("Transactional Table Migrations");

            foreach (var tableLink in _databaseParser.TableLinks)
            {
                if (ShouldSkipTable(tableLink.PrimaryTable.FullName))
                    continue;

                if (!LinearTableView.CanLinkToEmployer(tableLink))
                {
                    _missing.Add(tableLink);
                    continue;
                }

                var statement = CreateInsertQuery(tableLink, 1);
                statement = InjectQuery(tableCounter, tableLink.PrimaryTable, statement);
                ScriptWriter.WriteLine(statement);

                _tableCovered.Add(tableLink.PrimaryTable.FullName);
                tableCounter++;
            }
        }

        private string InjectQuery(int counter, DbTable table, string statement)
        {
            var builder = new StringBuilder();
            builder.AppendLine($"-- ***** [{counter}] Migrating {table.FullName} ***** ");
            
            builder.AppendLine(_appSettings.TableTemplate(table,statement));

            builder.AppendLine("".PadRight(50, '-'));
            builder.AppendLine("");
            return builder.ToString();
        }

        private string CreateInsertQuery(LinearTableView tableLink, int aliasCounter)
        {
            var pAlias = $"a{aliasCounter}";
            var queryBuilder = new StringBuilder();
            queryBuilder.Append(CreateInsert(tableLink.PrimaryTable, _dbSettings.TargetDatabase, pAlias));

            JoinNextTable(tableLink, queryBuilder, aliasCounter);
            return queryBuilder.ToString();
        }

        private void JoinNextTable(LinearTableView tableView, StringBuilder queryBuilder, int aliasCounter)
        {
            if(tableView == null)
                return;

            var pAlias = $"a{aliasCounter}";
            if (tableView.PrimaryTable.HasEmployerId)
            {
                queryBuilder.AppendLine(JoinEmployers(pAlias));
                return;
            }

            if(tableView.Next?.RightForeignTable == null)
                return;

            aliasCounter++;
            var cAlias = $"a{aliasCounter}";
            var rightTable = tableView.Next.RightForeignTable.PrimaryTable;
            queryBuilder.AppendLine($"INNER JOIN {rightTable.FullName} {cAlias} " +
                                    $"ON {pAlias}.{tableView.Next.LeftPrimaryTableKey} " +
                                    $"= {cAlias}.{tableView.Next.RightForeignTableKey}");
            
            JoinNextTable(tableView.Next.RightForeignTable, queryBuilder, aliasCounter);
        }


        private string JoinEmployers(string alias, string joinColumn = "employerId")
        {
            return $"INNER JOIN @EmployerIds eids ON eids.EmployerId = {alias}.{joinColumn}";
        }

        private string CreateInsert(DbTable targetTable, string targetDb, string alias)
        {
            var builder = new StringBuilder();
            builder.AppendLine($"INSERT INTO {targetDb}.{targetTable.FullName} ({targetTable.Csv()})");
            builder.AppendLine($"SELECT {targetTable.Csv(alias)}");
            builder.AppendLine($"FROM {targetTable.FullName} {alias}");
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

            foreach (var tableLink in _missing.OrderBy(p => p.PrimaryTable.Schema).ThenBy(p => p.PrimaryTable.Name))
            {
                if (ShouldSkipTable(tableLink.PrimaryTable.FullName))
                    continue;

                EventLogger.WriteLine($"   {counter}. {tableLink.PrimaryTable.FullName} - ({tableLink.PrimaryTable.Csv()})");
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