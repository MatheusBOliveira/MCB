using Newtonsoft.Json;
using System;

namespace MCB.Core.Infra.CrossCutting.Patterns.CommunicationProtocol.V1
{
    public class ApiRequest<TBody>
        : ApiRequest
    {
        [JsonIgnore]
        public Type BodyType => typeof(TBody);
    }
}


