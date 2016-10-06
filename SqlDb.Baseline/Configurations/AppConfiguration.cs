using System;
using System.Collections.Generic;
using System.Linq;
using SqlDb.Baseline.Helpers;
using SqlDb.Baseline.Models;

namespace SqlDb.Baseline.Configurations
{
    public interface IApplicationSetting
    {
        Func<DbTable, string, string> TableTemplate { get; }
        string OutputLocation { get; }
    }

    public class AppConfiguration : ConfigurationReader, IApplicationSetting
    {
        private readonly ProductsConfigurationSection _configSection;

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
        }

        public IList<string> Databases { get; }
        public DatabaseElementConfiguration GetDatabaseSetting(string database) => _configSection.Databases.FirstOrDefault(p => p.Name == database);

        public Func<DbTable, string, string> TableTemplate { get; }
        public string OutputLocation { get; }
    }
}