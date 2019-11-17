using MCB.Admin.Domain.DomainModels;
using MCB.Admin.Domain.Specifications.Customers.Interfaces;
using MCB.Core.Domain.DomainModels.Enums;
using MCB.Core.Infra.CrossCutting.Patterns.Specification.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace MCB.Admin.Domain.Specifications.Customers
{
    public class CustomerMustBeLegalPersonSpecification
        : SpecificationBase<Customer>,
        ICustomerMustBeLegalPersonSpecification
    {
        public CustomerMustBeLegalPersonSpecification()
        {
            ErrorCode = "MCB-ADMIN-DOMAIN-CUSTOMERS-11";
        }

        public override Task<bool> IsSatisfiedBy(Customer entity, CultureInfo culture)
        {
            return Task.FromResult(entity?.PersonType == PersonTypeEnum.Legal);
        }
    }
}
