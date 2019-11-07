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
    public class CustomerGovernamentalNumberForNaturalPersonIsValidSpecification
        : SpecificationBase<Customer>,
        ICustomerGovernamentalNumberForNaturalPersonIsValidSpecification
    {
        public CustomerGovernamentalNumberForNaturalPersonIsValidSpecification()
            : base()
        {
            ErrorCode = "MCB-ADMIN-DOMAIN-CUSTOMERS-4";
        }

        public override Task<bool> IsSatisfiedBy(Customer entity)
        {
            return Task.FromResult(
                entity?.PersonType == PersonTypeEnum.Natural
                && entity?.GovernamentalDocument?.IsValid() == true
                );
        }
    }
}
