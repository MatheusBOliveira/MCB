using MCB.Core.Infra.CrossCutting.Configuration.Interfaces;
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
        private Dictionary<string, object> _keyStoreDictionary;

        // Properties
        protected Dictionary<string, object> KeyStoreDictionary
        {
            get
            {
                return _keyStoreDictionary;
            }
            set
            {
                _keyStoreDictionary = value;
            }
        }

        protected abstract void GettingValue(string key, object gettingValue);
        protected abstract void ValueGeted(string key, object getedValue);
        protected abstract void SettingValue(string key, object proposedValue);
        protected abstract void ValueSeted(string key, object setedValue);

        public ConfigurationManagerBase()
        {
            KeyStoreDictionary = new Dictionary<string, object>();
        }

        public string Get(string key)
        {
            var value = string.Empty;

            GettingValue(key, value);

            if (KeyStoreDictionary.TryGetValue(key, out object keyStoreValue))
                value = keyStoreValue.ToString();

            ValueGeted(key, value);

            return value;
        }
        public T Get<T>(string key)
        {
            var value = default(T);

            GettingValue(key, value);

            if (KeyStoreDictionary.TryGetValue(key, out object keyStoreValue))
                value = (T)Convert.ChangeType(keyStoreValue, typeof(T));

            ValueGeted(key, value);

            return value;
        }
        public void Set(string key, object value)
        {
            SettingValue(key, value);

            if (!KeyStoreDictionary.ContainsKey(key))
                KeyStoreDictionary.Add(key, value);
            else
                KeyStoreDictionary[key] = value;

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
