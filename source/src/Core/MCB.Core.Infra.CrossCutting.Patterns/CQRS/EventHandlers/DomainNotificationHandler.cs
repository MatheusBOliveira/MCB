using MCB.Core.Infra.CrossCutting.Patterns.CommunicationProtocol.Enums;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.EventHandlers.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Patterns.CQRS.EventHandlers
{
    public class DomainNotificationHandler
        : IEventHandler<DomainNotification>,
        IDomainNotificationHandler
    {
        private readonly List<DomainNotification> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public virtual IEnumerable<DomainNotification> GetNotifications()
        {
            return _notifications.AsEnumerable();
        }
        public virtual bool HasNotifications()
        {
            return GetNotifications().Any();
        }
        public bool HasErrors()
        {
            return GetNotifications().Any(q => q.NotificationType == Notifications.Enums.DomainNotificationTypeEnum.Error);
        }

        public async Task<EventReturn> Handle(DomainNotification message, CancellationToken cancellationToken)
        {
            _notifications.Add(message);

            return await Task.FromResult(new EventReturn(true, true));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}


