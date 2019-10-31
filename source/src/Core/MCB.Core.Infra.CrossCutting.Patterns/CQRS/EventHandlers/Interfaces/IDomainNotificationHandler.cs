using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Notifications;
using System.Collections.Generic;

namespace MCB.Core.Infra.CrossCutting.Patterns.CQRS.EventHandlers.Interfaces
{
    public interface IDomainNotificationHandler
        : IEventHandler<DomainNotification>
    {
        IEnumerable<DomainNotification> GetNotifications();
        bool HasNotifications();
        bool HasErrors();
    }
}


