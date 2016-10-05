using System.Configuration;

namespace SqlDb.Baseline.Configurations
{
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
}