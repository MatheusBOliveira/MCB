using MCB.Core.Infra.CrossCutting.Patterns.CommunicationProtocol.Enums;

namespace MCB.Core.Infra.CrossCutting.Patterns.CommunicationProtocol
{
    public class Message
    {
        public MessageTypeEnum Type { get; set; }
        public string TypeDescription { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}


