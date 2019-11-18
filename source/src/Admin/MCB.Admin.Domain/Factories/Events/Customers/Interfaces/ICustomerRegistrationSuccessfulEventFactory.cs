using MCB.Admin.Domain.DomainModels;
using MCB.Admin.Domain.Events.Customers.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.Factory.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Admin.Domain.Factories.Events.Customers.Interfaces
{
    public interface ICustomerRegistrationSuccessfulEventFactory
        : IFactory<ICustomerRegistrationSuccessfulEvent>,
        IFactoryWithParameter<ICustomerRegistrationSuccessfulEvent, Customer>
    {

    }
}
