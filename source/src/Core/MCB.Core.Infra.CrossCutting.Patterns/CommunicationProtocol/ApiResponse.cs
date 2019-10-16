using System.Collections.Generic;

namespace MCB.Core.Infra.CrossCutting.Patterns.CommunicationProtocol
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public Header Header { get; set; }
        public List<Message> Messages { get; set; }

        public ApiResponse()
        {
            Header = new Header();
            Messages = new List<Message>();
        }

        public void AddErrorMessage(string code)
        {
            Messages.Add(new Message
            {
                Type = Enums.MessageTypeEnum.Error,
                Code = code
            });
        }
        public void AddErrorMessage(string[] codes)
        {
            foreach (var code in codes)
                AddErrorMessage(code);
        }
        public void AddErrorMessage(string code, string description)
        {
            Messages.Add(new Message
            {
                Type = Enums.MessageTypeEnum.Error,
                Code = code,
                Description = description
            });
        }
    }
}


