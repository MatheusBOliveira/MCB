using MCB.Core.Infra.CrossCutting.Configuration.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Core.Infra.CrossCutting.Configuration.Base
{
    public delegate void GetValueHandle(string key, object value);
    public delegate void SetValueHandle(string key, object value);

    public abstract class ConfigurationManagerBase
        : IConfigurationManager
    {
        // Attributes
        private JObject _jsonKeyStore;

        // Properties
        protected JObject JsonKeyStore
        {
            get
            {
                return _jsonKeyStore;
            }
            set
            {
                _jsonKeyStore = value;
            }
        }

        protected abstract void GettingValue(string key, object gettingValue);
        protected abstract void ValueGeted(string key, object getedValue);
        protected abstract void SettingValue(string key, object proposedValue);
        protected abstract void ValueSeted(string key, object setedValue);

        protected ConfigurationManagerBase()
        {
            JsonKeyStore = new JObject();
        }

        public string Get(string key)
        {
            var value = string.Empty;

            GettingValue(key, value);

            var searchValue = JsonKeyStore.SelectToken(key);
            if (searchValue != null)
                value = searchValue.ToString();

            ValueGeted(key, value);

            return value;
        }
        public T Get<T>(string key)
        {
            var returnValue = default(T);

            var value = Get(key);
            if (!string.IsNullOrWhiteSpace(value))
                returnValue = (T)Convert.ChangeType(value, typeof(T));

            return returnValue;
        }
        public void Set(string key, object value)
        {
            SettingValue(key, value);

            JsonKeyStore[key] = value.ToString();

            ValueSeted(key, value);
        }

        public abstract string GetEnvironmentName();
        public abstract void LoadConfigurations();
        public abstract void SaveConfigurations();

        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
