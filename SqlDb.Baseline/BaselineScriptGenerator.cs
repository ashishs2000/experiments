using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SqlDb.Baseline.Helpers;
using SqlDb.Baseline.Models;

namespace SqlDb.Baseline
{
    public class BaselineScriptGenerator
    {
        private readonly Database _database;
        private readonly ConfigurationSetting _setting;
        private readonly List<LinearTableView> _missing = new List<LinearTableView>();
        private readonly List<string> _tableCovered = new List<string>();

        private FileWriter ScriptWriter => _setting.ScriptWriter;
        private FileWriter LogWriter => _setting.LogFileWriter;

        public BaselineScriptGenerator(Database database, ConfigurationSetting setting)
        {
            _database = database;
            _setting = setting;
        }

        public void Generate()
        {
            var baseScript = File.ReadAllText("BeforeBaseline.sql");
            ScriptWriter.AddHeader("Base Script");
            ScriptWriter.WriteLine(baseScript);

            AppendLookupTableMigration();
            AppendTransactionTableMigration();
            LogMissingFile();
        }

        private void AppendLookupTableMigration()
        {
            var tableCounter = 1;
            ScriptWriter.AddHeader("Lookup Table Migrations");

            foreach (var tableName in _setting.LookupTables)
            {
                if(ShouldSkipTable(tableName))
                    continue;

                var table = _database.Tables.GetTable(tableName);
                var statement = CreateInsert(table, _setting.TargetServer, "a");
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

            foreach (var tableLink in _database.TableLinks)
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

        private void LogMissingFile()
        {
            var counter = 1;
            LogWriter.AddHeader($"Missing Table Migrations {_missing.Count}/{_database.TablesCount}");
            foreach (var tableLink in _missing.OrderBy(p => p.PrimaryTable.Schema).ThenBy(p => p.PrimaryTable.Name))
            {
                if (ShouldSkipTable(tableLink.PrimaryTable.FullName))
                    continue;

                LogWriter.WriteLine($"   {counter}. {tableLink.PrimaryTable.FullName} - ({tableLink.PrimaryTable.Csv()})");
                counter++;
            }
        }


        private string InjectQuery(int counter, DbTable table, string statement)
        {
            var builder = new StringBuilder();
            builder.AppendLine($"-- ***** [{counter}] Migrating {table.FullName} ***** ");
            
            builder.AppendLine(_setting.TableTemplate(table,statement));

            builder.AppendLine("".PadRight(50, '-'));
            builder.AppendLine("");
            return builder.ToString();
        }

        private string CreateInsertQuery(LinearTableView tableLink, int aliasCounter)
        {
            var pAlias = $"a{aliasCounter}";
            var queryBuilder = new StringBuilder();
            queryBuilder.Append(CreateInsert(tableLink.PrimaryTable, _setting.TargetServer, pAlias));

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
            if (_setting.SkipTables.Contains(tablename, new IgnoreCaseComparer()))
                return true;

            if (_tableCovered.Contains(tablename, new IgnoreCaseComparer()))
                return true;

            return false;
        }
    }
}