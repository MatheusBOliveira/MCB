using MCB.Admin.Domain.DomainModels;
using MCB.Admin.Domain.Events.Customers;
using MCB.Admin.Domain.Events.Customers.Interfaces;
using MCB.Admin.Domain.Factories.Events.Customers.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.Factory;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MCB.Admin.Domain.Factories.Events.Customers
{
    public class CustomerRegistrationFailEventFactory
        : FactoryBase<ICustomerRegistrationFailEvent>,
        ICustomerRegistrationFailEventFactory
    {
        public override ICustomerRegistrationFailEvent Create(CultureInfo culture)
        {
            return new CustomerRegistrationFailEvent();
        }

        public ICustomerRegistrationFailEvent Create((Customer customer, string registrationUsername) parameter, CultureInfo culture)
        {
            var customerRegistrationFailEvent = Create(culture);

            customerRegistrationFailEvent.AggregateId = parameter.customer?.DomainModel?.Id ?? Guid.Empty;
            customerRegistrationFailEvent.CultureInfo = culture;
            customerRegistrationFailEvent.Customer = parameter.customer;
            customerRegistrationFailEvent.Username = parameter.registrationUsername;

            return customerRegistrationFailEvent;
        }
    }
}
