using MCB.Admin.Domain.DomainModels;
using MCB.Core.Infra.CrossCutting.Patterns.Specification.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Admin.Domain.Specifications.Customers.Interfaces
{
    public interface ICustomerMustBeActiveInRepositorySpecification
        : ISpecification<Customer>
    {
    }
}
