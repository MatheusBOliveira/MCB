using Newtonsoft.Json;
using System;

namespace MCB.Core.Infra.CrossCutting.Patterns.CommunicationProtocol.V1
{
    public class ApiResponse<TBody>
        : ApiResponse
    {
        public TBody Body { get; set; }

        [JsonIgnore]
        public Type BodyType => typeof(TBody);
    }
}


