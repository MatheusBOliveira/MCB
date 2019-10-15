using System.Collections.Generic;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Cache.Interfaces
{
    public interface ICache
    {
        void AddOrUpdate(string key, string value);
        bool Delete(string key);
        Task<string> GetAsync(string key);
        Task<T> GetAsync<T>(string key);
        Task<Dictionary<string, string>> GetAllAsync();
    }
}


