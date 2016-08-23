using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Xml;

namespace ConfigCompare
{
    public class Program
    {
        static void Main(string[] args)
        {
            var source = ConfigurationReader.SourcePath;
            var target = ConfigurationReader.TargetPath;

            var sourceSettings = GetSettings(source);
            var targetSettings = GetSettings(target);

            var settings = new XmlWriterSettings();
            settings.Indent = true;

            var writer = XmlWriter.Create(ConfigurationReader.OutputPath, settings);
            writer.WriteStartDocument(true);
            writer.WriteStartElement("appSettings");

            var appendChanges = ConfigurationReader.AppendChanges;
            var sameValues = new Dictionary<string,string>();
            foreach (var sourceSetting in sourceSettings)
            {
                if (sourceSetting.IsComments)
                {
                    //AddComment(writer, sourceSetting.Value);
                    continue;
                }

                var targetSetting = targetSettings.FirstOrDefault(p => p.Key == sourceSetting.Key);
                if (targetSetting == null)
                {
                    CreateNode(writer, sourceSetting.Key, sourceSetting.Value);
                    continue;
                }

                if (sourceSetting.Value == targetSetting.Value)
                {
                    sameValues.Add(sourceSetting.Key,sourceSetting.Value);
                    continue;
                }

                CreateNode(writer, sourceSetting.Key, targetSetting.Value);
                if (appendChanges)
                    AddComment(writer, $"{sourceSetting.Value}", false);
            }

            AddComment(writer, "Common app settings between source and target");
            foreach (var sameValue in sameValues)
                CreateNode(writer, sameValue.Key, sameValue.Value);

            AddComment(writer, "Fields from target which are missing from source ");
            foreach (var targetSetting in targetSettings)
            {
                if(targetSetting.IsComments)
                    continue;

                var sourceSetting = sourceSettings.FirstOrDefault(p => p.Key == targetSetting.Key);
                if(sourceSetting != null)
                    continue;

                CreateNode(writer, targetSetting.Key, targetSetting.Value);
            }

            writer.WriteString("\n");
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }

        private static void CreateNode(XmlWriter writer, string key, string value)
        {
            writer.WriteString("\n");
            writer.WriteStartElement("add");
            writer.WriteAttributeString("key", key);
            writer.WriteAttributeString("value", value);
            writer.WriteEndElement();
        }

        private static void AddComment(XmlWriter writer, string comment, bool appendNewLine = true)
        {
            if (appendNewLine)
            {
                writer.WriteString("\n");
                writer.WriteString("\n");
            }
            writer.WriteComment($"{comment}");
        }

        private static IList<Setting> GetSettings(string path)
        {
            var myData = new XmlDocument();
            myData.Load(path);

            var settings = new List<Setting>();
            var nodes = myData.DocumentElement.ChildNodes;
            foreach (XmlNode node in nodes)
            {
                if (node.NodeType == XmlNodeType.Comment)
                {
                    settings.Add(new Setting { IsComments = true, Value = node.Value });
                    continue;
                }

                settings.Add(new Setting
                {
                    Key = node.Attributes["key"].Value,
                    Value = node.Attributes["value"].Value
                });
            }
            return settings;
        } 
    }

    public class Setting
    {
        public bool IsComments { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public static class ConfigurationReader
    {
        public static string SourcePath => Read<string>("sourcePath");
        public static string TargetPath => Read<string>("targetPath");
        public static string OutputPath => Read<string>("outputPath");
        public static bool AppendChanges => Read<bool>("appendChanges");
        
        private static T Read<T>(string key)
        {
            return (T)Convert.ChangeType(ConfigurationManager.AppSettings[key], typeof(T));
        }
    }
}
