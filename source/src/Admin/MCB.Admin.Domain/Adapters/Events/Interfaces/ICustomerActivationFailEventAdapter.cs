using MCB.Admin.Domain.Events.Customers;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Adapters.Events;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Adapters.Events.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Admin.Domain.Adapters.Events.Interfaces
{
    public interface ICustomerActivationFailEventAdapter
        : IEventAdapter<CustomerActivationFailEvent>
    {
    }
}
