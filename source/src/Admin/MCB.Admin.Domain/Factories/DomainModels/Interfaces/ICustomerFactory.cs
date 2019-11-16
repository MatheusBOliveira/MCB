using MCB.Admin.Domain.Commands.Customers;
using MCB.Admin.Domain.DomainModels;
using MCB.Core.Domain.DomainModels.Enums;
using MCB.Core.Infra.CrossCutting.Patterns.Factory.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Admin.Domain.Factories.DomainModels.Interfaces
{
    public interface ICustomerFactory
        : IFactory<Customer>,
        IFactoryWithParameter<Customer, PersonTypeEnum>,
        IFactoryWithParameter<Customer, ActiveCustomerCommand>,
        IFactoryWithParameter<Customer, RegisterNewCustomerCommand>
    {
    }
}
