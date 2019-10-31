using MCB.Core.Infra.CrossCutting.Patterns.CommunicationProtocol.Enums;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Notifications.Enums;

namespace MCB.Core.Infra.CrossCutting.Patterns.CQRS.Notifications
{
    public class DomainNotification
        : EventBase
    {
        public string Code { get; set; }
        public DomainNotificationTypeEnum NotificationType { get; set; }
        public string Message { get; set; }

        public DomainNotification(string code, string message, DomainNotificationTypeEnum notificationType = DomainNotificationTypeEnum.Error)
        {
            Code = code;
            NotificationType = notificationType;
            Message = message;
        }
    }
}


