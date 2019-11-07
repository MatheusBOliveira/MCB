using MCB.Admin.Domain.Commands.Customers;
using MCB.Admin.Domain.DomainModels;
using MCB.Admin.Domain.Factories.DomainModels.Interfaces;
using MCB.Core.Domain.DomainModels.Enums;
using MCB.Core.Domain.ValueObjects.Localization;
using MCB.Core.Infra.CrossCutting.Patterns.Factory;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MCB.Admin.Domain.Factories.DomainModels
{
    public class CustomerFactory
        : FactoryBase<Customer>,
        ICustomerFactory
    {
        public override Customer Create(CultureInfo cultureInfo)
        {
            return new LegalCustomer() {
                GovernamentalDocument = new CPFValueObject()
            };
        }

        public Customer Create(PersonTypeEnum parameter, CultureInfo cultureInfo)
        {
            return parameter switch
            {
            PersonTypeEnum.Natural => Create(cultureInfo),
            PersonTypeEnum.Legal => new LegalCustomer() {
                GovernamentalDocument = new CNPJValueObject()
                },
                _ => default,
            };
        }

        public Customer Create(ActiveCustomerCommand parameter, CultureInfo cultureInfo)
        {
            var customer = Create(cultureInfo);

            customer.Email = parameter.Email;

            return customer;
        }
    }
}
