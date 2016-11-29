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

        public IList<CustomScript> BeforeScripts { get; } = new List<CustomScript>();
        public IList<CustomScript> AfterScripts { get; } = new List<CustomScript>();

        public static CustomScripts GetCustomScript(IDatabaseConfig config)
        {
            CustomScripts result = new CustomScripts();
            if (string.IsNullOrEmpty(config.CustomScriptFile))
                return result;

            if (!File.Exists(config.CustomScriptFile))
            {
                ConsoleLogger.LogError($"No custom script file found '{config.CustomScriptFile}' for database '{config.SourceDatabase}'");
                return result;
            }

            var serializer = new XmlSerializer(typeof(CustomScripts));
            result = (CustomScripts) serializer.Deserialize(new FileStream(config.CustomScriptFile, FileMode.Open));

            var scripts = new List<CustomScript>();
            foreach (var script in result.Scripts)
            {
                script.Value = script.Value.Replace("@target", config.TargetDatabase).Replace("@source", config.SourceDatabase);
                switch (script.Sequence)
                {
                    case AppendSequence.Before:
                        result.BeforeScripts.Add(script);
                        break;
                    default:
                        result.AfterScripts.Add(script);
                        break;
                }
                scripts.Add(script);
            }

            return result;
        }
    }

    public class CustomScript
    {
        private string _table;
        private const AppendSequence DefaultSequence = AppendSequence.After;

        [XmlAttribute("table")]
        public string Table
        {
            get { return _table; }
            set { _table = value.ToLower(); }
        }

        [XmlAttribute("append")]
        public string Append { get; set; } = DefaultSequence.ToString();
        
        [XmlText]
        public string Value { get; set; }

        [XmlIgnore]
        public AppendSequence Sequence => Append.ToEnum(DefaultSequence);
    }

    public enum AppendSequence
    {
        Before,
        After
    }
}