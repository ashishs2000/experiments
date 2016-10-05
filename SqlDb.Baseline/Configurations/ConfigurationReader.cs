using System;
using System.Configuration;

namespace SqlDb.Baseline.Configurations
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