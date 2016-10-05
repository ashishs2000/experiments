using System;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;

namespace SqlDb.Baseline.Configurations
{
    public class ProductsConfigurationSection : ConfigurationSection
    {
        public static ProductsConfigurationSection GetConfiguration()
        {
            return (ProductsConfigurationSection)ConfigurationManager.GetSection("migrationSection");
        }
        
        [ConfigurationProperty("", IsDefaultCollection = true)]
        public DatabaseConfigurationCollection Databases => (DatabaseConfigurationCollection)base[""];
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

        [ConfigurationProperty("", IsDefaultCollection = true)]
        public MappingConfigurationCollection Settings => (MappingConfigurationCollection)base[""];
    }


    [ConfigurationCollection(typeof(MappingElement),AddItemName = "mappings")]
    public class MappingConfigurationCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement() => new MappingElement();
        protected override object GetElementKey(ConfigurationElement element) => ((MappingElement)element).Type;
    }

    public class MappingElement : ConfigurationElement
    {
        [ConfigurationProperty("maptype", IsRequired = true, IsKey = true)]
        [TypeConverter(typeof(CaseInsensitiveEnumConfigConverter<MappingType>))]
        public MappingType Type => (MappingType)this["maptype"];

        [ConfigurationProperty("", IsDefaultCollection = true)]
        public TableToColumnCollection Settings => (TableToColumnCollection)base[""];
    }

    [ConfigurationCollection(typeof(TableToColumnMapElement))]
    public class TableToColumnCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement() => new TableToColumnMapElement();
        protected override object GetElementKey(ConfigurationElement element) => ((TableToColumnMapElement)element).Table;
    }

    public class TableToColumnMapElement : ConfigurationElement
    {
        [ConfigurationProperty("table", IsRequired = true, IsKey = true)]
        public string Table => this["table"].ToString();

        [ConfigurationProperty("column", IsRequired = false)]
        public string Column => this["column"].ToString();
    }

    public enum MappingType
    {
        Ignore,
        Relation,
        Lookup
    }

    public class CaseInsensitiveEnumConfigConverter<T> : ConfigurationConverterBase
    {
        public override object ConvertFrom(ITypeDescriptorContext ctx, CultureInfo ci, object data)
        {
            return Enum.Parse(typeof(T), (string) data, true);
        }
    }
}