using System.Collections.Generic;

namespace MCB.Core.Infra.CrossCutting.Patterns.CommunicationProtocol
{
    public class ApiRequest
    {
        public Header Header { get; set; }
        public List<Message> Messages { get; set; }

        public ApiRequest()
        {
            Header = new Header();
            Messages = new List<Message>();
        }
    }
}


