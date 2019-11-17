using MCB.Admin.Domain.DomainModels;
using MCB.Admin.Domain.Factories.Queries.Customers.Interfaces;
using MCB.Admin.Domain.Queries.Customers;
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
    public class CustomerMustBeInactiveInRepositorySpecification
        : SpecificationBase<Customer>,
        ICustomerMustBeInactiveInRepositorySpecification
    {
        private readonly ISagaManager _sagaManager;
        private readonly IGetCustomerByIdQueryFactory _getCustomerByIdQueryFactory;

        public CustomerMustBeInactiveInRepositorySpecification(
            ISagaManager sagaManager,
            IGetCustomerByIdQueryFactory getCustomerByIdQueryFactory)
        {
            ErrorCode = "MCB-ADMIN-DOMAIN-CUSTOMERS-9";

            _sagaManager = sagaManager;
            _getCustomerByIdQueryFactory = getCustomerByIdQueryFactory;
        }

        public override async Task<bool> IsSatisfiedBy(Customer entity, CultureInfo culture)
        {
            var getCustomerByIdQuery = _getCustomerByIdQueryFactory.Create(entity, culture);
            var localizedCustomer = await _sagaManager.GetQuery<IGetCustomerByIdQuery, Customer>(getCustomerByIdQuery, culture);

            return localizedCustomer?.ReturnObject?.ActivableInfo?.IsActive == false;
        }
    }
}
