using MCB.Admin.Domain.DomainModels;
using MCB.Admin.Domain.Specifications.Customers.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.Specification.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using MCB.Core.Infra.CrossCutting.ExtensionMethods;

namespace MCB.Admin.Domain.Specifications.Customers
{
    public class CustomerNameValidLengthSpecification
        : SpecificationBase<Customer>,
        ICustomerNameValidLengthSpecification
    {
        public CustomerNameValidLengthSpecification()
        {
            ErrorCode = "MCB-ADMIN-DOMAIN-CUSTOMERS-16";
        }

        public override Task<bool> IsSatisfiedBy(Customer entity, CultureInfo culture)
        {
            if (string.IsNullOrWhiteSpace(entity?.Name))
                return Task.FromResult(true);

            return Task.FromResult(entity.Name.LengthIsBetween(1, 50));
        }
    }
}
