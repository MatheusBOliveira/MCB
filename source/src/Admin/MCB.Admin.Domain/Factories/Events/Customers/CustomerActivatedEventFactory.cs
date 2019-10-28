﻿using MCB.Admin.Domain.DomainModels;
using MCB.Admin.Domain.Events.Customers;
using MCB.Admin.Domain.Factories.Events.Customers.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Admin.Domain.Factories.Events.Customers
{
    public class CustomerActivatedEventFactory
        : FactoryBase<CustomerActivatedEvent>,
        ICustomerActivatedEventFactory
    {
        public override CustomerActivatedEvent Create()
        {
            return new CustomerActivatedEvent();
        }

        public CustomerActivatedEvent Create((Customer customer, string username) parameter)
        {
            var @event = Create();

            @event.ActivatedCustomer = parameter.customer;
            @event.Username = parameter.username;

            return @event;
        }
    }
}