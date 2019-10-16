using System;

namespace MCB.Core.Infra.CrossCutting.Patterns.CommunicationProtocol
{
    public class Auth
    {
        public string Token { get; set; }
        public Guid ApplicationId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}


