using MCB.Admin.Domain.Commands.Customers;
using MCB.Core.Infra.CrossCutting.Patterns.Specification.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Admin.Domain.Specifications.Commands.Customers.ActiveCustomerCommands.Interfaces
{
    public interface IEmailIsRequiredSpecification
        : ISpecification<ActiveCustomerCommand>
    {
    }
}
