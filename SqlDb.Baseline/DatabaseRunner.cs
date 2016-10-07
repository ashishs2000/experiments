using System;
using SqlDb.Baseline.ConfigSections;
using SqlDb.Baseline.Query;

namespace SqlDb.Baseline
{
    public class DatabaseRunner : IDisposable
    {
        private readonly AppConfiguration _appConfiguration;
        private readonly DatabaseElementConfiguration _configuration;

        public DatabaseRunner(AppConfiguration configuration, string database)
        {
            _appConfiguration = configuration;
            _configuration = configuration.GetDatabaseSetting(database);
        }

        public void Execute(bool generateInsertScript)
        {
            var tables = new TableQuery(_configuration);
            Logger.LogInfo($"Total extracted tables and views - {tables.AllObjects.Count}");

            var relations = new TableRelationshipQuery(_configuration);
            Logger.LogInfo($"Total relationships found in database - {relations.Relationships.Count}");

            Logger.LogInfo("Parsing and analysing gathered database information");
            var database = new DatabaseParser(tables, relations, _configuration);
            database.LoadRelations();

            Logger.LogInfo("Generating baseline script");
            var query = new BaselineScriptGenerator(database, _appConfiguration, _configuration);
            query.GenerateInsertScript = generateInsertScript;
            query.Generate();

            Logger.LogInfo($"Baseline script path - '{_configuration.OutputLocation}'");
        }

        public void Dispose()
        {
            _configuration.ScriptLogger.Dispose();
        }
    }
}