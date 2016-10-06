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

        public void Execute()
        {
            var tables = new TableQuery(_configuration);
            var relations = new TableRelationshipQuery(_configuration);

            var database = new DatabaseParser(tables, relations, _configuration);
            database.LoadRelations();

            var query = new BaselineScriptGenerator(database, _appConfiguration, _configuration);
            query.Generate();
        }

        public void Dispose()
        {
            _configuration.ScriptLogger.Dispose();
        }
    }
}