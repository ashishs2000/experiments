using System;
using SqlDb.Baseline.ConfigSections;
using SqlDb.Baseline.Helpers;
using SqlDb.Baseline.Models;
using SqlDb.Baseline.Query;
using SqlDb.Baseline.QueryCommand;

namespace SqlDb.Baseline
{
    public class DatabaseRunner : IDisposable
    {
        private readonly AppConfiguration _appConfiguration;
        private readonly DatabaseElementConfiguration _configuration;
        private readonly QueryScripts _scripts;

        public DatabaseRunner(AppConfiguration configuration, DatabaseElementConfiguration dbConfiguration, QueryScripts scripts)
        {
            _appConfiguration = configuration;
            _configuration = dbConfiguration;
            _scripts = scripts;
        }

        public void Execute(bool generateInsertScript)
        {
            var tables = new TableQuery(_scripts, _configuration);
            var relations = new TableRelationshipQuery(_scripts, _configuration);

            ConsoleLogger.LogInfo("Parsing and analysing gathered database information");
            var database = new DatabaseParser(tables, relations, _configuration);
            database.LoadRelations();

            ConsoleLogger.LogInfo("Generating baseline script");

            var command = generateInsertScript
                ? (IQueryCommand) new InsertQueryCommand(_appConfiguration, _configuration)
                : new SelectQueryCommand(_appConfiguration);

            var query = new BaselineScriptGenerator(database, _configuration, command);
            query.Generate();

            ConsoleLogger.LogInfo($"Baseline script path - '{_configuration.OutputLocation}'");
        }

        public void Dispose()
        {
            _configuration.ScriptLogger.Dispose();
        }
    }
}