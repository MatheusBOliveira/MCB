using MCB.Admin.Domain.Events.Customers;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.EventHandlers;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.EventHandlers.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MCB.Admin.Domain.EventHandlers.Customers
{
    public class CustomerEventHandler
        : EventHandlerBase,
        IEventHandler<CustomerRegistrationSuccessfulEvent>,
        IEventHandler<CustomerRegistrationFailEvent>
    {
        public Task<EventReturn> Handle(CustomerRegistrationSuccessfulEvent message, CultureInfo culture, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
        public Task<EventReturn> Handle(CustomerRegistrationFailEvent message, CultureInfo culture, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
