using MCB.Admin.Domain.DomainModels;
using MCB.Admin.Domain.Factories.Queries.Customers.Interfaces;
using MCB.Admin.Domain.Queries.Customers;
using MCB.Core.Infra.CrossCutting.Patterns.Factory;
using MCB.Core.Infra.CrossCutting.Patterns.Factory.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MCB.Admin.Domain.Factories.Queries.Customers
{
    public class GetCustomerByEmailAddressQueryFactory
        : FactoryBase<GetCustomerByEmailAddressQuery>,
        IGetCustomerByEmailAddressQueryFactory
    {
        public override GetCustomerByEmailAddressQuery Create(CultureInfo culture)
        {
            return new GetCustomerByEmailAddressQuery();
        }

        public GetCustomerByEmailAddressQuery Create(Customer parameter, CultureInfo culture)
        {
            var query = Create(culture);

            query.EmailAddress = parameter?.Email?.EmailAddress;

            return query;
        }
    }
}
