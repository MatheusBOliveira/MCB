using MCB.Core.Infra.CrossCutting.ExtensionMethods;
using MCB.Core.Infra.CrossCutting.Gateway.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Gateway
{
    public class GatewayManager
    {
        public Route[] RouteCollection { get; set; }

        public void LoadJsonFiles(string[] jsonFileCollection)
        {
            var json = string.Empty;
            var routeCollection = new List<Route>();

            foreach (var jsonFile in jsonFileCollection)
            {
                using (var streamWriter = new StreamReader(jsonFile))
                    json = streamWriter.ReadToEnd();

                routeCollection.AddRange(json.DeserializeFromJson<Route[]>());
            }

            RouteCollection = routeCollection.ToArray();
        }
        private Route GetRoute(string requestRelativePath, string requestedVerb)
        {
            return RouteCollection.FirstOrDefault(q =>
                q.RelativePath.ToLower().Equals(requestRelativePath)
                && q.AcceptedVerbs.Contains(requestedVerb));
        }

        public async Task<TReturn> RouteRequest<TReturn>(
            string requestRelativePath, 
            string queryString, 
            byte[] body, 
            Dictionary<string, string> header,
            string requestedVerb,
            Func<(string RoutedUri, string Verb, byte[] Body), TReturn> handle)
        {
            var route = GetRoute(requestRelativePath, requestedVerb);

            if(route == null)
            {
                //TODO: Send error code message
                return await Task.FromResult(default(TReturn));
            }

            return await route.SendRequest(queryString, body, header, requestedVerb, handle);
        }
    }
}


