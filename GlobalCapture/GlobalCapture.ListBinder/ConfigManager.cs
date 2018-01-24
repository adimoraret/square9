using System;
using System.Configuration;

namespace GlobalCapture.ListBinder
{
    public class ConfigManager
    {
        private string ConfigPath => GetType().Assembly.Location;

        public string GetAppSetting(string key)
        {
            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigPath);
                return GetAppSetting(config, key);
            }
            catch (Exception)
            {
                return "";
            }
        }

        private static string GetAppSetting(Configuration config, string key)
        {
            var element = config.AppSettings.Settings[key];
            var value = element?.Value;
            return !string.IsNullOrEmpty(value) ? value : string.Empty;
        }
    }
}