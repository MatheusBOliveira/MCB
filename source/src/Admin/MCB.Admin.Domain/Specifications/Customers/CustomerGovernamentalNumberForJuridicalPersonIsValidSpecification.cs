using MCB.Admin.Domain.DomainModels;
using MCB.Admin.Domain.Specifications.Customers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MCB.Admin.Domain.Specifications.Customers
{
    public class CustomerGovernamentalNumberForJuridicalPersonIsValidSpecification
        : ICustomerGovernamentalNumberForJuridicalPersonIsValidSpecification
    {
        public string ErrorCode => "MCB-ADMIN-DOMAIN-CUSTOMERS-3";

        public string ErrorDefaultDescription => nameof(CustomerGovernamentalNumberForJuridicalPersonIsValidSpecification);

        public Task<bool> IsSatisfiedBy(Customer entity)
        {
            return Task.FromResult(entity?.GovernamentalDocument?.IsValid() == true);
        }
    }
}
