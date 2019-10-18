using MCB.Core.Infra.CrossCutting.Configuration.Base;
using MCB.Core.Infra.CrossCutting.Configuration.Interfaces;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;

        public ConfigurationManager()
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true)
                .AddEnvironmentVariables();

            if (!string.IsNullOrWhiteSpace(environmentName))
                builder.AddJsonFile($"appsettings.{environmentName}.json", true, true);

            _configuration = builder.Build();

            GettingValueEvent += ConfigurationManager_GettingValueEvent;
            SettingValueEvent += ConfigurationManager_SettingValueEvent;
        }

        private void ConfigurationManager_GettingValueEvent(string key, object value)
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
        private void ConfigurationManager_SettingValueEvent(string key, object value)
        {
            throw new NotImplementedException();
        }

        private static string GetAppSettingsFile()
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            return !string.IsNullOrWhiteSpace(environmentName)
                ? $"appsettings.{environmentName}.json"
                : "appsettings.json";
        }
    }
}
