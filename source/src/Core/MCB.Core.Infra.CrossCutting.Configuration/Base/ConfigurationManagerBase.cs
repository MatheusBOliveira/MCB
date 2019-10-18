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

        // Events
        protected event GetValueHandle GettingValueEvent;
        protected event GetValueHandle ValueGetedEvent;
        protected event SetValueHandle SettingValueEvent;
        protected event SetValueHandle ValueSetedEvent;

        public ConfigurationManagerBase()
        {
            KeyStoreDictionary = new Dictionary<string, object>();
        }

        public string Get(string key)
        {
            var value = string.Empty;

            GettingValueEvent?.Invoke(key, value);

            if (KeyStoreDictionary.TryGetValue(key, out object keyStoreValue))
                value = keyStoreValue.ToString();

            ValueGetedEvent?.Invoke(key, value);

            return value;
        }
        public T Get<T>(string key)
        {
            var value = default(T);

            GettingValueEvent?.Invoke(key, value);

            if (KeyStoreDictionary.TryGetValue(key, out object keyStoreValue))
                value = (T)Convert.ChangeType(keyStoreValue, typeof(T));

            ValueGetedEvent?.Invoke(key, value);

            return value;
        }
        public void Set(string key, object value)
        {
            SettingValueEvent?.Invoke(key, value);

            if (!KeyStoreDictionary.ContainsKey(key))
                KeyStoreDictionary.Add(key, value);
            else
                KeyStoreDictionary[key] = value;

            ValueSetedEvent?.Invoke(key, value);
        }

        public abstract void LoadConfigurations();

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
