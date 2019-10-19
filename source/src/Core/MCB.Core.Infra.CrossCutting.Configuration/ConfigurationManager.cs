using MCB.Core.Infra.CrossCutting.Configuration.Base;
using MCB.Core.Infra.CrossCutting.Configuration.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace MCB.Core.Infra.CrossCutting.Configuration
{
    /*
     * see https://docs.microsoft.com/en-us/aspnet/core/fundamentals/environments?view=aspnetcore-3.0
     */

    public class ConfigurationManager
        : ConfigurationManagerBase,
        IConfigurationManager
    {
        private readonly Dictionary<string, string> _configFilesDictionary;
        private IConfiguration _configuration;

        public ConfigurationManager()
        {
            _configFilesDictionary = new Dictionary<string, string>();
        }

        private void ConfigurationManager_GettingValueEvent(string key, object value)
        {
            try
            {
                var configValue = _configuration[key];

                // Update KeyStore based on IConfiguration
                if (!string.IsNullOrWhiteSpace(configValue))
                {
                    if (!KeyStoreDictionary.ContainsKey(key))
                        KeyStoreDictionary.Add(key, configValue);
                    else
                        KeyStoreDictionary[key] = configValue;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void ConfigurationManager_SettingValueEvent(string key, object value)
        {
            
        }
        private void ConfigurationManager_ValueSetedEvent(string key, object value)
        {
            SaveConfigurations();
            UpdateKeyStoreByJsonString();
        }

        private string GetAppSettingsFile()
        {
            var environmentName = GetEnvironmentName();

            return !string.IsNullOrWhiteSpace(environmentName)
                ? $"appsettings.{environmentName}.json"
                : "appsettings.json";
        }

        public override string GetEnvironmentName()
        {
            return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "development";
        }
        public override void LoadConfigurations()
        {
            var environmentName = GetEnvironmentName();

            var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile($"appsettings.json", true, true)
                .AddEnvironmentVariables();

            _configFilesDictionary.Add(
                "appsettings.json",
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json"));

            if (!string.IsNullOrWhiteSpace(environmentName))
            {
                builder.AddJsonFile($"appsettings.{environmentName}.json", true, true);

                _configFilesDictionary.Add(
                    $"appsettings.{environmentName}.json",
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"appsettings.{environmentName}.json"));
            }
            _configuration = builder.Build();

            UpdateKeyStoreByJsonString();

            GettingValueEvent += ConfigurationManager_GettingValueEvent;
            SettingValueEvent += ConfigurationManager_SettingValueEvent;

            ValueSetedEvent += ConfigurationManager_ValueSetedEvent;
        }

        private void UpdateKeyStoreByJsonString()
        {
            var jsonFileContent = string.Empty;

            using (var sr = new StreamReader(_configFilesDictionary[GetAppSettingsFile()]))
                jsonFileContent = sr.ReadToEnd();

            KeyStoreDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonFileContent);
        }


        public override void SaveConfigurations()
        {
            var appSettingsFullName = _configFilesDictionary[GetAppSettingsFile()];
            var configJson = JsonConvert.SerializeObject(KeyStoreDictionary);

            using (var sw = new StreamWriter(appSettingsFullName, false, Encoding.UTF8))
            {
                sw.WriteLine(configJson);
            }
        }
    }
}
