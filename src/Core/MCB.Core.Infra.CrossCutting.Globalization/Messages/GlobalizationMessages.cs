using System.Collections.Generic;

namespace MCB.Core.Infra.CrossCutting.Globalization.Messages
{
    public class GlobalizationMessages
    {
        public string Code { get; set; }
        public Dictionary<string, string> Messages { get; set; }

        public GlobalizationMessages()
        {
            Messages = new Dictionary<string, string>();
        }
    }
}


