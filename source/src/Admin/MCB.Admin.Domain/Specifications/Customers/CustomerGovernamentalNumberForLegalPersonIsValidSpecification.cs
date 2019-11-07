using MCB.Admin.Domain.DomainModels;
using MCB.Admin.Domain.Specifications.Customers.Interfaces;
using MCB.Core.Domain.DomainModels.Enums;
using MCB.Core.Infra.CrossCutting.Patterns.Specification.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MCB.Admin.Domain.Specifications.Customers
{
    public class CustomerGovernamentalNumberForLegalPersonIsValidSpecification
        : SpecificationBase<Customer>,
        ICustomerGovernamentalNumberForLegalPersonIsValidSpecification
    {
        public CustomerGovernamentalNumberForLegalPersonIsValidSpecification()
            : base()
        {
            ErrorCode = "MCB-ADMIN-DOMAIN-CUSTOMERS-3";
        }

        public override Task<bool> IsSatisfiedBy(Customer entity)
        {
            return Task.FromResult(
                entity?.PersonType == PersonTypeEnum.Legal
                && entity?.GovernamentalDocument?.IsValid() == true
                );
        }
    }
}
