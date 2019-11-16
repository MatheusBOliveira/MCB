using MCB.Admin.Domain.DomainModels;
using MCB.Admin.Domain.Factories.Queries.Customers.Interfaces;
using MCB.Admin.Domain.Queries.Customers.Interfaces;
using MCB.Admin.Domain.Specifications.Customers.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Saga.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.Specification.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace MCB.Admin.Domain.Specifications.Customers
{
    public class CustomerEmailMustBeUniqueInRepositorySpecification
        : SpecificationBase<Customer>,
        ICustomerEmailMustBeUniqueInRepositorySpecification
    {
        private readonly ISagaManager _sagaManager;
        private readonly IGetCustomerByEmailAddressQueryFactory _getCustomerByEmailAddressQueryFactory;

        public CustomerEmailMustBeUniqueInRepositorySpecification(
            ISagaManager sagaManager,
            IGetCustomerByEmailAddressQueryFactory getCustomerByEmailAddressQueryFactory
            )
        {
            ErrorCode = "MCB-ADMIN-DOMAIN-CUSTOMERS-2";

            _sagaManager = sagaManager;
            _getCustomerByEmailAddressQueryFactory = getCustomerByEmailAddressQueryFactory;
        }

        public override async Task<bool> IsSatisfiedBy(Customer entity, CultureInfo culture)
        {
            var getCustomerByEmailAddressQuery = _getCustomerByEmailAddressQueryFactory.Create(entity, culture);
            var localizedCustomer = await _sagaManager.GetQuery<IGetCustomerByEmailAddressQuery, Customer>(getCustomerByEmailAddressQuery,culture);

            return localizedCustomer == null;
        }
    }
}
