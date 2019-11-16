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
        public override Customer Create(CultureInfo culture)
        {
            GovernamentalNumberValueObject governamentalNumber;

            switch (culture.Name)
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
                GovernamentalNumber = governamentalNumber
            };
        }

        public Customer Create(PersonTypeEnum parameter, CultureInfo culture)
        {
            var customer = Create(culture);

            if (parameter == PersonTypeEnum.Natural)
                return customer;

            GovernamentalNumberValueObject governamentalNumber;

            switch (culture.Name)
            {
                case "pt-BR":
                    governamentalNumber = new CNPJValueObject();
                    break;
                default:
                    governamentalNumber = new CNPJValueObject();
                    break;
            }

            customer.GovernamentalNumber = governamentalNumber;

            return customer;
        }

        public Customer Create(ActiveCustomerCommand parameter, CultureInfo culture)
        {
            var customer = Create(culture);

            customer.Email = parameter.Email;

            return customer;
        }

        public Customer Create(RegisterNewCustomerCommand parameter, CultureInfo culture)
        {
            var customer = Create(culture);

            customer.Email = parameter.Email;
            customer.Name = parameter.Name;
            customer.PhoneNumber = parameter.PhoneNumber;
            customer.GovernamentalNumber = parameter.GovernamentalNumber;

            return customer;
        }
    }
}
