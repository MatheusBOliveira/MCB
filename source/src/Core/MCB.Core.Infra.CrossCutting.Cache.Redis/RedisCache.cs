using MCB.Core.Infra.CrossCutting.Cache.Redis.Interfaces;
using MCB.Core.Infra.CrossCutting.Configuration.Interfaces;
using MCB.Core.Infra.CrossCutting.ExtensionMethods;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Cache.Redis
{
    public class RedisCache
        : IRedisCache
    {
        private readonly ConnectionMultiplexer _redis;
        private readonly IServer _redisServer;
        private readonly IDatabase _redisDatabase;

        public RedisCache(ConnectionMultiplexer redis,
            IConfigurationManager config)
        {
            _redis = redis;
            _redisServer = _redis.GetServer(config.Get("redis.server"));
            _redisDatabase = _redis.GetDatabase();
        }

        public void AddOrUpdate(string key, string value)
        {
            _redisDatabase.StringSet(key, value);
        }

        public bool Delete(string key)
        {
            return _redisDatabase.KeyDelete(key);
        }

        public async Task<string> GetAsync(string key)
        {
            var redisValue = await _redisDatabase.StringGetAsync(key);
            return redisValue.ToString();
        }

        public async Task<T> GetAsync<T>(string key)
        {
            var cacheValue = await GetAsync(key);
            return cacheValue.DeserializeFromJson<T>();
        }

        public async Task<Dictionary<string, string>> GetAllAsync()
        {
            var dictionary = new Dictionary<string, string>();

            var keys = _redisServer.Keys().ToList();
            foreach (var key in keys)
                dictionary.Add(key.ToString(), await GetAsync(key.ToString()));

            return dictionary;
        }
    }
}


