using MCB.Core.Infra.CrossCutting.Bus.Interfaces.EventHandlers;
using MCB.Core.Infra.CrossCutting.Bus.ReturnObjects;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Bus.EventHandlers
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


