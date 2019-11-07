using MCB.Admin.Domain.DomainModels;
using MCB.Admin.Domain.Factories.Queries.Customers.Interfaces;
using MCB.Admin.Domain.Queries.Customers;
using MCB.Core.Infra.CrossCutting.Patterns.Factory;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MCB.Admin.Domain.Factories.Queries.Customers
{
    public class GetCustomerByIdQueryFactory
        : FactoryBase<GetCustomerByIdQuery>,
        IGetCustomerByIdQueryFactory
    {
        public override GetCustomerByIdQuery Create(CultureInfo culture)
        {
            return new GetCustomerByIdQuery();
        }

        public GetCustomerByIdQuery Create(Customer parameter, CultureInfo culture)
        {
            var returnObject = Create(culture);

            returnObject.CustomerId = parameter.DomainModel.Id;

            return returnObject;
        }
    }
}
