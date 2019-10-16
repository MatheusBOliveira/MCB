using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Gateway.Models
{
    public class HttpDestination
        : Destination
    {
        private static HttpClient _httpClient;
        public static HttpClient HttpClient
        {
            get
            {
                if (_httpClient == null)
                    _httpClient = new HttpClient();

                return _httpClient;
            }
        }

        public string Uri { get; set; }

        public HttpDestination()
        {
            DestinationType = Enums.DestinationTypeEnum.Http;
        }

        private string CreateDestinationUri(string queryString)
        {
            return $"{Uri}{queryString}";
        }

        public async Task<TReturn> SendRequest<TReturn>(
            string queryString,
            byte[] body,
            Dictionary<string, string> header,
            string requestedVerb,
            Func<(string RoutedUri, string Verb, byte[] Body), TReturn> handle)
        {
            var destinationUri = CreateDestinationUri(queryString);

            return await Task.FromResult(handle.Invoke((destinationUri, requestedVerb, body)));
        }
    }
}


