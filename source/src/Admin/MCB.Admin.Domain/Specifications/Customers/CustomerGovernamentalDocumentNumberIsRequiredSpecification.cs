using MCB.Admin.Domain.DomainModels;
using MCB.Admin.Domain.Specifications.Customers.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.Specification.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace MCB.Admin.Domain.Specifications.Customers
{
    public class CustomerGovernamentalDocumentNumberIsRequiredSpecification
        : SpecificationBase<Customer>,
        ICustomerGovernamentalDocumentNumberIsRequiredSpecification
    {
        public CustomerGovernamentalDocumentNumberIsRequiredSpecification()
            : base()
        {
            ErrorCode = "MCB-ADMIN-DOMAIN-CUSTOMERS-2";
        }

        public override Task<bool> IsSatisfiedBy(Customer entity, CultureInfo cultureInfo)
        {
            return Task.FromResult(!string.IsNullOrWhiteSpace(entity?.GovernamentalDocument?.DocumentNumber));
        }
    }
}
