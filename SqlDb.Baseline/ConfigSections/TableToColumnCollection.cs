using System.Collections.Generic;
using System.Configuration;

namespace SqlDb.Baseline.ConfigSections
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
        protected string TableColumns => this["column"].ToString();

        public IList<string> Columns => TableColumns.Split(',');
    }
}