using MCB.Admin.Domain.DomainModels;
using MCB.Admin.Domain.Specifications.Customers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MCB.Admin.Domain.Specifications.Customers
{
    public class CustomerGovernamentalDocumentNumberIsRequiredSpecification
        : ICustomerGovernamentalDocumentNumberIsRequiredSpecification
    {
        public string ErrorCode => "MCB-ADMIN-DOMAIN-CUSTOMERS-2";
        public string ErrorDefaultDescription => nameof(CustomerGovernamentalDocumentNumberIsRequiredSpecification);

        public Task<bool> IsSatisfiedBy(Customer entity)
        {
            return Task.FromResult(!string.IsNullOrWhiteSpace(entity.GovernamentalDocumentNumber));
        }
    }
}
