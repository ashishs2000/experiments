using System.IO;
using System.Xml.Serialization;
using SqlDb.Baseline.ConfigSections;

namespace SqlDb.Baseline.Models
{
    [XmlRoot("scripts")]
    public class QueryScripts
    {
        [XmlElement("script")]
        public QueryScript[] Scripts { get; set; }

        public static QueryScripts Load(IApplicationSetting settings)
        {
            var serializer = new XmlSerializer(typeof(QueryScripts));
            var data = (QueryScripts)serializer.Deserialize(new FileStream(settings.QueryScriptFile, FileMode.Open));
            
            foreach (var script in data.Scripts)
            {
                switch (script.Type)
                {
                    case "TABLE_QUERY":
                        data.TableQuery = script.Value;
                        break;
                    case "VIEW_QUERY":
                        data.ViewQuery = script.Value;
                        break;
                    case "TABLE_IDENTITY_QUERY":
                        data.TableIdentityQuery = script.Value;
                        break;
                    case "TABLE_RELATIONSHIP_QUERY":
                        data.TableRelationshipQuery = script.Value;
                        break;
                }
            }
            return data;
        }

        [XmlIgnore]
        public string TableQuery { get; private set; }
        [XmlIgnore]
        public string ViewQuery { get; private set; }
        [XmlIgnore]
        public string TableIdentityQuery { get; private set; }
        [XmlIgnore]
        public string TableRelationshipQuery { get; private set; }
    }

    public class QueryScript
    {
        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlText]
        public string Value { get; set; }
    }
}