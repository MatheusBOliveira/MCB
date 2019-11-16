﻿using MCB.Admin.Domain.DomainModels;
using MCB.Core.Infra.CrossCutting.Patterns.Specification.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Admin.Domain.Validations.Customers.Interfaces
{
    public interface ICustomerIsValidForRegistrationValidation
        : IValidator<Customer>
    {
    }
}
