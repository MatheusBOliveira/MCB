using MCB.Admin.Domain.DomainModels;
using MCB.Admin.Domain.Specifications.Customers.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Saga.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.Specification.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MCB.Admin.Domain.Specifications.Customers
{
    public class CustomerMustBeActiveSpecification
        : SpecificationBase<Customer>,
        ICustomerMustBeActiveSpecification
    {
        private readonly ISagaManager _sagaManager;

        public CustomerMustBeActiveSpecification(
            ISagaManager sagaManager)
            : base()
        {
            ErrorCode = "MCB-ADMIN-DOMAIN-CUSTOMERS-6";

            _sagaManager = sagaManager;
        }

        public override Task<bool> IsSatisfiedBy(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
