using MCB.Admin.Domain.DomainModels;
using MCB.Admin.Domain.Events.Customers;
using MCB.Core.Infra.CrossCutting.Patterns.Factory.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Admin.Domain.Factories.Events.Customers.Interfaces
{
    public interface ICustomerActivatedEventFactory
        : IFactory<CustomerActivatedEvent>,
        IFactoryWithParameter<CustomerActivatedEvent, (Customer customer, string username)>
    {
    }
}
