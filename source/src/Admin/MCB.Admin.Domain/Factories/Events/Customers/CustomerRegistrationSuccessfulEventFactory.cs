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
    public class CustomerRegistrationSuccessfulEventFactory
        : FactoryBase<ICustomerRegistrationSuccessfulEvent>,
        ICustomerRegistrationSuccessfulEventFactory
    {
        public override ICustomerRegistrationSuccessfulEvent Create(CultureInfo culture)
        {
            return new CustomerRegistrationSuccessfulEvent();
        }

        public ICustomerRegistrationSuccessfulEvent Create(Customer parameter, CultureInfo culture)
        {
            var customerRegistrationSuccessfulEvent = Create(culture);

            customerRegistrationSuccessfulEvent.AggregateId = parameter.DomainModel.Id;
            customerRegistrationSuccessfulEvent.CultureInfo = culture;
            customerRegistrationSuccessfulEvent.RegisteredCustomer = parameter;
            customerRegistrationSuccessfulEvent.Username = parameter.AuditableInfo.CreatedUser;

            return customerRegistrationSuccessfulEvent;
        }
    }
}
