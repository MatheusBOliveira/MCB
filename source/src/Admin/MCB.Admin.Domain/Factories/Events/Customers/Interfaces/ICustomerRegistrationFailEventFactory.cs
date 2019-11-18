using MCB.Admin.Domain.DomainModels;
using MCB.Admin.Domain.Events.Customers.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.Factory.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Admin.Domain.Factories.Events.Customers.Interfaces
{
    public interface ICustomerRegistrationFailEventFactory
        : IFactory<ICustomerRegistrationFailEvent>,
        IFactoryWithParameter<ICustomerRegistrationFailEvent, (Customer customer, string registrationUsername)>
    {

    }
}
