using MCB.Admin.Domain.Commands.Customers;
using MCB.Admin.Domain.DomainModels;
using MCB.Admin.Domain.Factories.DomainModels.Interfaces;
using MCB.Core.Domain.DomainModels.Enums;
using MCB.Core.Domain.ValueObjects;
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
            GovernamentalNumberValueObject governamentalNumber;

            switch (cultureInfo.Name)
            {
                case "pt-BR":
                    governamentalNumber = new CPFValueObject();
                    break;
                default:
                    governamentalNumber = new CPFValueObject();
                    break;
            }

            return new LegalCustomer()
            {
                GovernamentalDocument = governamentalNumber
            };
        }

        public Customer Create(PersonTypeEnum parameter, CultureInfo cultureInfo)
        {
            var customer = Create(cultureInfo);

            if (parameter == PersonTypeEnum.Natural)
                return customer;

            GovernamentalNumberValueObject governamentalNumber;

            switch (cultureInfo.Name)
            {
                case "pt-BR":
                    governamentalNumber = new CNPJValueObject();
                    break;
                default:
                    governamentalNumber = new CNPJValueObject();
                    break;
            }

            customer.GovernamentalDocument = governamentalNumber;

            return customer;
        }

        public Customer Create(ActiveCustomerCommand parameter, CultureInfo cultureInfo)
        {
            var customer = Create(cultureInfo);

            customer.Email = parameter.Email;

            return customer;
        }
    }
}
