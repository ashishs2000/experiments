using System.ComponentModel;
using System.Configuration;
using SqlDb.Baseline.Helpers;

namespace SqlDb.Baseline.Configurations
{
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

    public enum MappingType
    {
        Ignore,
        Relation,
        Lookup
    }
}