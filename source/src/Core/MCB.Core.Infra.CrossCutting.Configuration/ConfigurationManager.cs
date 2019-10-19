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
using System.Threading;

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

        public ConfigurationManager()
        {
            _configFilesDictionary = new Dictionary<string, string>();
        }

        private string GetAppSettingsFile()
        {
            var environmentName = GetEnvironmentName();

            return !string.IsNullOrWhiteSpace(environmentName)
                ? $"appsettings.{environmentName}.json"
                : "appsettings.json";
        }
        private void UpdateKeyStoreFromJsonFile()
        {
            var jsonFileContent = string.Empty;

            KeyStoreDictionary.Clear();

            foreach (var configFileKeyParValue in _configFilesDictionary)
            {
                if (!File.Exists(configFileKeyParValue.Value))
                    continue;

                using (var sr = new StreamReader(configFileKeyParValue.Value))
                    jsonFileContent = sr.ReadToEnd();

                var jsonDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonFileContent);
                foreach (var jsonItem in jsonDictionary)
                {
                    if (KeyStoreDictionary.ContainsKey(jsonItem.Key))
                        KeyStoreDictionary[jsonItem.Key] = jsonItem.Value;
                    else
                        KeyStoreDictionary.Add(jsonItem.Key, jsonItem.Value);
                }
            }
        }
        private void UpdateConfigs()
        {
            UpdateKeyStoreFromJsonFile();
        }

        protected override void GettingValue(string key, object gettingValue)
        {
            try
            {
                UpdateConfigs();
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected override void ValueGeted(string key, object getedValue)
        {

        }
        
        protected override void SettingValue(string key, object proposedValue)
        {

        }
        protected override void ValueSeted(string key, object setedValue)
        {
            SaveConfigurations();
        }

        public override string GetEnvironmentName()
        {
            return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "development";
        }
        public override void LoadConfigurations()
        {
            var environmentName = GetEnvironmentName();

            _configFilesDictionary.Add(
                "appsettings.json",
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json"));

            if (!string.IsNullOrWhiteSpace(environmentName))
                _configFilesDictionary.Add(
                    $"appsettings.{environmentName}.json",
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"appsettings.{environmentName}.json"));

            UpdateKeyStoreFromJsonFile();
        }

        public override void SaveConfigurations()
        {
            var appSettingsFullName = _configFilesDictionary[GetAppSettingsFile()];
            var configJson = JsonConvert.SerializeObject(KeyStoreDictionary);

            using (var sw = new StreamWriter(appSettingsFullName, false, Encoding.UTF8))
                sw.WriteLine(configJson);

            Thread.Sleep(1000);
        }
    }
}
