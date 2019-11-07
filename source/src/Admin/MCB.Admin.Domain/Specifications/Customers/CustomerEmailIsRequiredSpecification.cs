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
    public class CustomerEmailIsRequiredSpecification
        : SpecificationBase<Customer>,
        ICustomerEmailIsRequiredSpecification
    {
        public CustomerEmailIsRequiredSpecification()
            : base()
        {
            ErrorCode = "MCB-ADMIN-DOMAIN-CUSTOMERS-1";
        }

        public override Task<bool> IsSatisfiedBy(Customer entity, CultureInfo cultureInfo)
        {
            return Task.FromResult(!string.IsNullOrEmpty(entity?.Email?.EmailAddress));
        }
    }
}
