﻿using MCB.Admin.Domain.Queries.Applications.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MCB.Admin.Domain.Queries.Applications
{
    public class GetApplicationsByCustomerEmailAddressQuery
        : QueryBase,
        IGetApplicationsByCustomerEmailAddressQuery
    {
        public string EmailAddress { get; set; }

        public override void Validate()
        {
            ValidationResult = new Core.Infra.CrossCutting.Patterns.Specification.ValidationResult();
        }
    }
}
