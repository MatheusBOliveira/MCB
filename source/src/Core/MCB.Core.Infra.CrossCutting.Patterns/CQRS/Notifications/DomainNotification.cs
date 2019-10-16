using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;

namespace MCB.Core.Infra.CrossCutting.Patterns.CQRS.Notifications
{
    public class DomainNotification
        : EventBase
    {
        public string Code { get; set; }
        public string Message { get; set; }

        public DomainNotification(string code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}


