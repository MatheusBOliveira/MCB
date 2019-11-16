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
    public class CustomerGovernamentalNumberForLegalPersonIsValidSpecification
        : SpecificationBase<Customer>,
        ICustomerGovernamentalNumberForLegalPersonIsValidSpecification
    {
        public CustomerGovernamentalNumberForLegalPersonIsValidSpecification()
            : base()
        {
            ErrorCode = "MCB-ADMIN-DOMAIN-CUSTOMERS-4";
        }

        public override Task<bool> IsSatisfiedBy(Customer entity, CultureInfo culture)
        {
            if (entity?.PersonType != PersonTypeEnum.Legal)
                return Task.FromResult(true);

            return Task.FromResult(
                entity?.PersonType == PersonTypeEnum.Legal
                && entity?.GovernamentalNumber?.IsValid() == true
                );
        }
    }
}
