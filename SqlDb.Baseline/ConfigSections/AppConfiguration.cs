using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SqlDb.Baseline.Helpers;
using SqlDb.Baseline.Models;

namespace SqlDb.Baseline.ConfigSections
{
    public interface IApplicationSetting
    {
        string QueryScriptFile { get; }
        SqlTemplate InsertTemplate { get; }
        SqlTemplate SelectTemplate { get; }
        CommandType CommandType { get; }
        string OutputLocation { get; }
    }

    public class AppConfiguration : ConfigurationReader, IApplicationSetting
    {
        private readonly ProductsConfigurationSection _configSection;
        public IList<string> Databases { get; }
        public string QueryScriptFile { get; }
        public SqlTemplate InsertTemplate { get; }
        public SqlTemplate SelectTemplate { get; }
        public string OutputLocation { get; }
        public CommandType CommandType { get; }

        public AppConfiguration(CommandType commandType)
        {
            ConsoleLogger.LogInfo("Reading Configurations");

            CommandType = commandType;
            OutputLocation = ReadOrDefaultProperty("OutputLocation", "Output");
            QueryScriptFile = ReadOrDefaultProperty("QueryScriptFile", "QueryScript.xml");

            _configSection = ProductsConfigurationSection.GetConfiguration(this);
            Databases = _configSection.Databases.Select(p => p.SourceDatabase).ToList();

            var intertTemplate = File.ReadAllText("SqlTemplates/InsertOutputTemplate.txt");
            InsertTemplate = Parse(intertTemplate);

            var selectTemplate = File.ReadAllText("SqlTemplates/SelectOutputTemplate.txt");
            SelectTemplate = Parse(selectTemplate);
        }

        public DatabaseElementConfiguration GetDatabaseSetting(string database) => _configSection.Databases.FirstOrDefault(p => p.SourceDatabase == database);

        private static SqlTemplate Parse(string template)
        {
            var before = Between(template, "<before>", "</before>");
            var statement = Between(template, "<body>", "</body>");
            var after = Between(template, "<after>", "</after>");
            return new SqlTemplate(before,statement,after);
        }

        private static string Between(string target, string starttag, string endtag)
        {
            var pos1 = target.IndexOf(starttag, StringComparison.Ordinal) + starttag.Length;
            var pos2 = target.IndexOf(endtag, StringComparison.Ordinal);
            return target.Substring(pos1, pos2 - pos1);
        }
    }
}