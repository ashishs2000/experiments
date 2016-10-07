using System;
using System.Configuration;
using SqlDb.Baseline.Helpers;

namespace SqlDb.Baseline.ConfigSections
{
    public abstract class ConfigurationReader
    {
        protected T ReadOrDefaultProperty<T>(string key, T defaultValue)
        {
            try
            {
                return ReadProperty<T>(key);
            }
            catch (Exception ex)
            {
                LogFile.Error(ex);
                return defaultValue;
            }
        }

        private T ReadProperty<T>(string key)
        {
            var stringConfigValue = ConfigurationManager.AppSettings[key];
            if (stringConfigValue == null)
                throw new SettingsPropertyNotFoundException($"Configuration key '{key}' not found");

            return (T)Convert.ChangeType(stringConfigValue, typeof(T));
        }
    }
}