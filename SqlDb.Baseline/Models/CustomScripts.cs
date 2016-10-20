using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using SqlDb.Baseline.ConfigSections;
using SqlDb.Baseline.Helpers;

namespace SqlDb.Baseline.Models
{
    [XmlRoot("scripts")]
    public class CustomScripts
    {
        [XmlElement("script")]
        public CustomScript[] Scripts { get; set; }

        public static List<CustomScript> GetCustomScript(IDatabaseConfig config)
        {
            if (string.IsNullOrEmpty(config.CustomScriptFile))
                return new List<CustomScript>();

            if (!File.Exists(config.CustomScriptFile))
            {
                ConsoleLogger.LogError($"No custom script file found '{config.CustomScriptFile}' for database '{config.SourceDatabase}'");
                return new List<CustomScript>();
            }

            var serializer = new XmlSerializer(typeof(CustomScripts));
            var data = (CustomScripts) serializer.Deserialize(new FileStream(config.CustomScriptFile, FileMode.Open));

            var scripts = new List<CustomScript>();
            foreach (var script in data.Scripts)
            {
                script.Value = script.Value.Replace("@target", config.TargetDatabase).Replace("@source", config.SourceDatabase);
                scripts.Add(script);
            }

            return scripts;
        }
    }

    public class CustomScript
    {
        private string _table;

        [XmlAttribute("table")]
        public string Table
        {
            get { return _table; }
            set { _table = value.ToLower(); }
        }

        [XmlText]
        public string Value { get; set; }
    }
}