﻿using MCB.Admin.Domain.DomainModels;
using MCB.Admin.Domain.Events.Customers.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Admin.Domain.Events.Customers
{
    public class CustomerInactivationFailEvent
        : EventBase, 
        ICustomerInactivationFailEvent
    {
        public Customer Customer { get; set; }
    }
}
