using MCB.Admin.Domain.Commands.Customers;
using MCB.Admin.Domain.DomainModels;
using MCB.Admin.Domain.Factories.DomainModels.Interfaces;
using MCB.Core.Domain.DomainModels.Enums;
using MCB.Core.Infra.CrossCutting.Patterns.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Admin.Domain.Factories.DomainModels
{
    public class CustomerFactory
        : FactoryBase<Customer>,
        ICustomerFactory
    {
        public override Customer Create()
        {
            return new LegalCustomer();
        }

        public Customer Create(PersonTypeEnum parameter)
        {
            return parameter switch
            {
                PersonTypeEnum.Natural => new NaturalCustomer(),
                PersonTypeEnum.Legal => new LegalCustomer(),
                _ => default,
            };
        }

        public Customer Create(ActiveCustomerCommand parameter)
        {
            var customer = Create();

            customer.Email = parameter.Email;

            return customer;
        }
    }
}
