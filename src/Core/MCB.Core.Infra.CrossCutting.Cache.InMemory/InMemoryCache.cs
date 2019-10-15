using MCB.Core.Infra.CrossCutting.Cache.InMemory.Interfaces;
using MCB.Core.Infra.CrossCutting.ExtensionMethods;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Cache.InMemory
{
    public class InMemoryCache
        : IInMemoryCache
    {
        private readonly Dictionary<string, string> _keyStore;

        public InMemoryCache()
        {
            _keyStore = new Dictionary<string, string>();
        }

        public void AddOrUpdate(string key, string value)
        {
            if (!_keyStore.ContainsKey(key))
                _keyStore.Add(key, value);
            else
                _keyStore[key] = value;
        }
        public bool Delete(string key)
        {
            return _keyStore.Remove(key);
        }
        public async Task<string> GetAsync(string key)
        {
            return await Task.FromResult(_keyStore.ContainsKey(key) ? _keyStore[key] : string.Empty);
        }
        public async Task<T> GetAsync<T>(string key)
        {
            var value = await GetAsync(key);

            if (string.IsNullOrEmpty(value))
                return default;

            return value.DeserializeFromJson<T>();
        }
        public async Task<Dictionary<string, string>> GetAllAsync()
        {
            return await Task.FromResult(new Dictionary<string, string>(_keyStore));
        }
    }
}


