using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SqlDb.Baseline.Models;

namespace SqlDb.Baseline.ConfigSections
{
    public interface IApplicationSetting
    {
        string InsertOutputBeforeTemplate { get; }
        string InsertOutputAfterTemplate { get; }
        string SelectOutputBeforeTemplate { get; }
        string SelectOutputAfterTemplate { get; }
        CommandType CommandType { get; }
        Func<DbTable, string, string> TableTemplate { get; }
        string OutputLocation { get; }
    }

    public class AppConfiguration : ConfigurationReader, IApplicationSetting
    {
        private readonly ProductsConfigurationSection _configSection;
        public IList<string> Databases { get; }
        public string InsertOutputBeforeTemplate { get; }
        public string InsertOutputAfterTemplate { get; }
        public string SelectOutputBeforeTemplate { get; }
        public string SelectOutputAfterTemplate { get; }
        public Func<DbTable, string, string> TableTemplate { get; }
        public string OutputLocation { get; }
        public CommandType CommandType { get; }

        public AppConfiguration(CommandType commandType)
        {
            Logger.LogInfo("Reading Configurations");

            CommandType = commandType;
            var template = ReadOrDefaultProperty("InsertTableTemplate", "");

            TableTemplate = (table, statement) =>
            {
                var temp = template.Replace("{tablename}", table.FullName);
                temp = temp.Replace("{statement}", statement);
                return temp;
            };
            OutputLocation = ReadOrDefaultProperty("OutputLocation", "Output");

            _configSection = ProductsConfigurationSection.GetConfiguration(this);
            Databases = _configSection.Databases.Select(p => p.Name).ToList();

            var intertTemplate = File.ReadAllText("SqlTemplates/InsertOutputTemplate.txt");
            InsertOutputBeforeTemplate = Between(intertTemplate, "<before>", "</before>");
            InsertOutputAfterTemplate = Between(intertTemplate, "<after>", "</after>");

            var selectTemplate = File.ReadAllText("SqlTemplates/SelectOutputTemplate.txt");
            SelectOutputBeforeTemplate = Between(selectTemplate, "<before>", "</before>");
            SelectOutputAfterTemplate = Between(selectTemplate, "<before>", "</before>");
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