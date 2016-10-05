using System;
using System.Collections.Generic;
using SqlDb.Baseline.Models;

namespace SqlDb.Baseline.Helpers
{
    public class ConfigurationSetting
    {
        private readonly Dictionary<string,string> _mappers = new Dictionary<string, string>(); 
        private readonly List<string> _lookups;
        private readonly List<string> _skipTables = new List<string>();

        public string TargetServer { get; set; }
        public FileWriter LogFileWriter { get; set; }
        public FileWriter ScriptWriter { get; set; }

        public IDictionary<string, string> TableToEmployerMappers => _mappers;
        public IList<string> LookupTables => _lookups;
        public IList<string> SkipTables => _skipTables;

        public Func<DbTable, string, string> TableTemplate =
            (table, statement) => $@"
IF NOT EXISTS (SELECT 1 FROM Migrations.Baseline WHERE TableName = '{table.FullName}')
BEGIN
	TRUNCATE TABLE {table.FullName}

	{statement}
	INSERT INTO Migrations.Baseline(TableName,IsCompleted)
	SELECT '{table.FullName}',1
END";

        public ConfigurationSetting()
        {
            TargetServer = "test";
            LogFileWriter = new FileWriter("Log.txt");
            ScriptWriter = new FileWriter("baselineMigration.sql");
            
            _mappers.Add("dbo.Goals","GoalId");
            _mappers.Add("dbo.Competencies", "CompetencyID");
            _mappers.Add("dbo.CompetencyGroups", "CompetencyGroupID");
            _mappers.Add("dbo.Trainings", "TrainingID");
            _mappers.Add("dbo.NeogovTasks", "TaskID");
            _mappers.Add("dbo.Programs", "ProgramID");

            _lookups = new List<string>
            {
                "configuration.notificationreceivertype",
                "dbo.culture",
                "configuration.eventtype",
                "configuration.menu",
            };

            _skipTables = new List<string>
            {
                "Migrations.Baseline",
                "ngv.auditdata",
                "dbo.bulkoperations",
                "dataimport.dataimporttransactionstatuses",
                "dataimport.rawdatarecordstatuses",
                "dbo.elmah_error"
            };
        }
    }
}