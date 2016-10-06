using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SqlDb.Baseline.Models;

namespace SqlDb.Baseline.ConfigSections
{
    public interface IApplicationSetting
    {
        string OutputFileBeforeData { get; }
        string OutputFileAfterData { get; }

        Func<DbTable, string, string> TableTemplate { get; }
        string OutputLocation { get; }
    }

    public class AppConfiguration : ConfigurationReader, IApplicationSetting
    {
        private readonly ProductsConfigurationSection _configSection;
        public IList<string> Databases { get; }
        public string OutputFileBeforeData { get; }
        public string OutputFileAfterData { get; }
        public Func<DbTable, string, string> TableTemplate { get; }
        public string OutputLocation { get; }

        public AppConfiguration()
        {
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

            var outputTemplate = File.ReadAllText("BaselineTemplate.txt");
            OutputFileBeforeData = Between(outputTemplate, "<before>", "</before>");
            OutputFileAfterData = Between(outputTemplate, "<after>", "</after>");
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