using MCB.Admin.Domain.DomainModels;
using MCB.Admin.Domain.Specifications.Customers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MCB.Admin.Domain.Specifications.Customers
{
    public class CustomerEmailIsRequiredSpecification
        : ICustomerEmailIsRequiredSpecification
    {
        public string ErrorCode => "MCB-ADMIN-DOMAIN-CUSTOMERS-1";
        public string ErrorDefaultDescription => nameof(CustomerEmailIsRequiredSpecification);

        public Task<bool> IsSatisfiedBy(Customer entity)
        {
            return Task.FromResult(!string.IsNullOrEmpty(entity?.Email?.EmailAddress));
        }
    }
}
