using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using SqlDb.Baseline.Helpers;

namespace SqlDb.Baseline.Configurations
{
    public class ProductsConfigurationSection : ConfigurationSection
    {
        public static ProductsConfigurationSection GetConfiguration()
        {
            var section = (ProductsConfigurationSection)ConfigurationManager.GetSection("migrationSection");
            foreach (var database in section.Databases)
                database.ParseAndLoad();
            return section;
        }
        
        [ConfigurationProperty("", IsDefaultCollection = true)]
        public DatabaseConfigurationCollection DatabasesConfigs => (DatabaseConfigurationCollection)base[""];

        public IEnumerable<DatabaseElementConfiguration> Databases => DatabasesConfigs.Cast<DatabaseElementConfiguration>();
    }

    [ConfigurationCollection(typeof(DatabaseElementConfiguration),AddItemName = "database")]
    public class DatabaseConfigurationCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement() => new DatabaseElementConfiguration();
        protected override object GetElementKey(ConfigurationElement element) => ((DatabaseElementConfiguration)(element)).Name;
    }

    public class DatabaseElementConfiguration : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name => this["name"].ToString();

        [ConfigurationProperty("target")]
        public string TargetDatabase => this["target"].ToString();

        [ConfigurationProperty("output")]
        public string OutputFile => this["output"].ToString();

        [ConfigurationProperty("", IsDefaultCollection = true)]
        public MappingConfigurationCollection Mappings => (MappingConfigurationCollection)base[""];

        public FileWriter ScriptLogger { get; private set; }
        public IList<TableColumn> TableToEmployerMappers { get; set; }
        public IList<string> LookupTables { get; set; }
        public IList<string> SkipTables { get; set; }

        public DatabaseElementConfiguration()
        {
            TableToEmployerMappers = new List<TableColumn>();
            LookupTables = new List<string>();
            SkipTables = new List<string>();
        }

        public void ParseAndLoad()
        {
            ScriptLogger = new FileWriter(OutputFile);
            foreach (MappingElement mapping in Mappings)
            {
                switch (mapping.Type)
                {
                    case MappingType.Ignore:
                        foreach (TableToColumnMapElement setting in mapping.Settings)
                            SkipTables.Add(setting.Table);
                        break;
                    case MappingType.Relation:
                        foreach (TableToColumnMapElement setting in mapping.Settings)
                            setting.Columns.ForEach(col => TableToEmployerMappers.Add(new TableColumn(setting.Table,col)));
                        break;
                    case MappingType.Lookup:
                        foreach (TableToColumnMapElement setting in mapping.Settings)
                            LookupTables.Add(setting.Table);
                        break;
                }
            }
        }
    }

    public class TableColumn
    {
        public TableColumn(string table, string column)
        {
            Table = table;
            Column = column;
        }

        public string Table { get; private set; }
        public string Column { get; private set; }
    }
}