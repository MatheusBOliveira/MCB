﻿using MCB.Admin.Domain.DomainModels;
using MCB.Admin.Domain.Events.Customers;
using MCB.Admin.Domain.Factories.Events.Customers.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.Factory;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MCB.Admin.Domain.Factories.Events.Customers
{
    public class CustomerActivationFailEventFactory
        : FactoryBase<CustomerActivationFailEvent>,
        ICustomerActivationFailEventFactory
    {
        public override CustomerActivationFailEvent Create(CultureInfo culture)
        {
            return new CustomerActivationFailEvent();
        }

        public CustomerActivationFailEvent Create((Customer customer, string username) parameter, CultureInfo culture)
        {
            var @event = Create(culture);

            @event.Customer = parameter.customer;
            @event.Username = parameter.username;

            return @event;
        }
    }
}
