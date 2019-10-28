using MCB.Admin.Domain.Adapters.Events.Interfaces;
using MCB.Admin.Domain.Events.Customers;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Adapters.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Admin.Domain.Adapters.Events
{
    public class CustomerActivationFailEventAdapter
        : EventAdapterBase<CustomerActivationFailEvent>,
        ICustomerActivationFailEventAdapter
    {

    }
}
