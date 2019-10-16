using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Gateway.Models
{
    public class Route
    {
        public string Description { get; set; }
        public string RelativePath { get; set; }
        public string[] AcceptedVerbs { get; set; }
        public HttpDestination HttpDestination { get; set; }
        public QueueDestination QueueDestination { get; set; }

        private async Task<TReturn> SendHttpRequest<TReturn>(string queryString,
            byte[] body,
            Dictionary<string, string> header,
            string requestedVerb,
            Func<(string RoutedUri, string Verb, byte[] Body), TReturn> handle)
        {
            if (HttpDestination == null)
                return await Task.FromResult(default(TReturn));

            return await HttpDestination.SendRequest(queryString, body, header, requestedVerb, handle);
        }
        private async Task SendQueueRequest()
        {
            if (QueueDestination == null)
                return;

            await Task.FromResult(true);
        }

        public async Task<TReturn> SendRequest<TReturn>(
            string queryString,
            byte[] body,
            Dictionary<string, string> header,
            string requestedVerb,
            Func<(string RoutedUri, string Verb, byte[] Body), TReturn> handle)
        {
            await SendQueueRequest();
            return await SendHttpRequest(queryString, body, header, requestedVerb, handle);
        }
    }
}


