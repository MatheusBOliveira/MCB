using MCB.Admin.Domain.DomainModels;
using MCB.Admin.Domain.Factories.Queries.Customers.Interfaces;
using MCB.Admin.Domain.Queries.Customers;
using MCB.Admin.Domain.Queries.Customers.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.Factory;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MCB.Admin.Domain.Factories.Queries.Customers
{
    public class GetCustomerByIdQueryFactory
        : FactoryBase<IGetCustomerByIdQuery>,
        IGetCustomerByIdQueryFactory
    {
        public override IGetCustomerByIdQuery Create(CultureInfo culture)
        {
            return new GetCustomerByIdQuery();
        }

        public IGetCustomerByIdQuery Create(Customer parameter, CultureInfo culture)
        {
            var returnObject = Create(culture);

            returnObject.CustomerId = parameter.DomainModel.Id;

            return returnObject;
        }
    }
}
