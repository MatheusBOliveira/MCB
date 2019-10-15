using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Utils
{
    public class WebUtils
    {
        private readonly HttpClient _httpClient;

        public WebUtils()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> GetAsync(string requestUri, Dictionary<string, string> headerEntries)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            if (headerEntries.ContainsKey("Authorization"))
            {
                _httpClient.DefaultRequestHeaders.Add("Authorization", headerEntries["Authorization"]);
            }

            var response = await _httpClient.GetAsync(requestUri);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> PostAsync(string requestUri, string content, Dictionary<string, string> headerEntries)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            if (headerEntries.ContainsKey("Authorization"))
            {
                _httpClient.DefaultRequestHeaders.Add("Authorization", headerEntries["Authorization"]);
            }

            var response = await _httpClient.PostAsync(
                requestUri,
                new StringContent(
                    content, Encoding.UTF8, "application/json"
            ));

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> PutAsync(string requestUri, string content, Dictionary<string, string> headerEntries)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            if (headerEntries.ContainsKey("Authorization"))
            {
                _httpClient.DefaultRequestHeaders.Add("Authorization", headerEntries["Authorization"]);
            }

            var response = await _httpClient.PutAsync(
                requestUri,
                new StringContent(
                    content, Encoding.UTF8, "application/json"
            ));

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> DeleteAsync(string requestUri, Dictionary<string, string> headerEntries)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            if (headerEntries.ContainsKey("Authorization"))
            {
                _httpClient.DefaultRequestHeaders.Add("Authorization", headerEntries["Authorization"]);
            }

            var response = await _httpClient.DeleteAsync(
                requestUri
            );

            return await response.Content.ReadAsStringAsync();
        }

    }
}


