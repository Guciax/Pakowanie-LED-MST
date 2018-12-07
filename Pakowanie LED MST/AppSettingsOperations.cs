﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Pakowanie_LED_MST
{
    class AppSettingsOperations
    {
        public static void AddOrUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }

        public static string GetSettings(string key)
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            return configFile.AppSettings.Settings[key].Value;
            //return ConfigurationManager.open.AppSettings[key];
        }

        public static void CheckAppSettingsKeys()
        {
            try
            {
                AppSettingsOperations.GetSettings("CheckLedTest");
            }
            catch
            {
                AppSettingsOperations.AddOrUpdateAppSettings("CheckLedTest", "1");
            }

            try
            {
                AppSettingsOperations.GetSettings("CheckViTest");
            }
            catch
            {
                AppSettingsOperations.AddOrUpdateAppSettings("CheckViTest", "1");
            }
        }
    }
}
