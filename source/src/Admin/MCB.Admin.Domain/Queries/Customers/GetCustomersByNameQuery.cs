using MCB.Admin.Domain.Queries.Customers.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MCB.Admin.Domain.Queries.Customers
{
    public class GetCustomersByNameQuery
        : QueryBase,
        IGetCustomersByNameQuery
    {
        public override void Validate()
        {
            ValidationResult = new Core.Infra.CrossCutting.Patterns.Specification.ValidationResult();
        }
    }
}
