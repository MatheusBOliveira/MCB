using MCB.Core.Infra.CrossCutting.Bus.Interfaces.EventHandlers;
using MCB.Core.Infra.CrossCutting.Bus.ReturnObjects;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Bus.InMemory.Tests.Handlers.DomainNotificationHandler
{
    public class DomainNotificationHandler
        : IDomainNotificationHandler
    {
        private List<DomainNotification> _messageList;

        public DomainNotificationHandler()
        {
            _messageList = new List<DomainNotification>();
        }

        public async Task<EventReturn> Handle(DomainNotification message, CancellationToken cancellationToken)
        {
            _messageList.Add(message);

            return await Task.FromResult(new EventReturn(true, true));
        }

        public IEnumerable<DomainNotification> GetNotifications()
        {
            return _messageList.AsEnumerable();
        }
        public bool HasNotifications()
        {
            return _messageList.Any();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}


