using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SqlDb.Baseline.Models;

namespace SqlDb.Baseline.ConfigSections
{
    public interface IApplicationSetting
    {
        SqlTemplate InsertTemplate { get; }
        SqlTemplate SelectTemplate { get; }
        CommandType CommandType { get; }
        string OutputLocation { get; }
    }

    public class AppConfiguration : ConfigurationReader, IApplicationSetting
    {
        private readonly ProductsConfigurationSection _configSection;
        public IList<string> Databases { get; }
        public SqlTemplate InsertTemplate { get; }
        public SqlTemplate SelectTemplate { get; }
        public string OutputLocation { get; }
        public CommandType CommandType { get; }

        public AppConfiguration(CommandType commandType)
        {
            Logger.LogInfo("Reading Configurations");

            CommandType = commandType;
            OutputLocation = ReadOrDefaultProperty("OutputLocation", "Output");

            _configSection = ProductsConfigurationSection.GetConfiguration(this);
            Databases = _configSection.Databases.Select(p => p.Name).ToList();

            var intertTemplate = File.ReadAllText("SqlTemplates/InsertOutputTemplate.txt");
            InsertTemplate = new SqlTemplate
            {
                Before = Between(intertTemplate, "<before>", "</before>"),
                Statement = Between(intertTemplate, "<body>", "</body>"),
                After = Between(intertTemplate, "<after>", "</after>")
            };

            var selectTemplate = File.ReadAllText("SqlTemplates/SelectOutputTemplate.txt");
            SelectTemplate = new SqlTemplate
            {
                Before = Between(selectTemplate, "<before>", "</before>"),
                After = Between(selectTemplate, "<after>", "</after>")
            };
        }

        public DatabaseElementConfiguration GetDatabaseSetting(string database) => _configSection.Databases.FirstOrDefault(p => p.Name == database);
        
        private static string Between(string target, string starttag, string endtag)
        {
            var pos1 = target.IndexOf(starttag, StringComparison.Ordinal) + starttag.Length;
            var pos2 = target.IndexOf(endtag, StringComparison.Ordinal);
            return target.Substring(pos1, pos2 - pos1);
        }
    }
}