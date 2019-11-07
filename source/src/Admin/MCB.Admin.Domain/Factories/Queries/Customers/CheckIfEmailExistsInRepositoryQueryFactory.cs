using MCB.Admin.Domain.Factories.Queries.Customers.Interfaces;
using MCB.Admin.Domain.Queries.Customers;
using MCB.Core.Domain.Factories.ValueObjects.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.Factory;
using MCB.Core.Infra.CrossCutting.Patterns.Factory.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MCB.Admin.Domain.Factories.Queries.Customers
{
    public class CheckIfEmailExistsInRepositoryQueryFactory
        : FactoryBase<CheckIfEmailExistsInRepositoryQuery>,
        ICheckIfEmailExistsInRepositoryQueryFactory
    {
        private readonly IEmailValueObjectFactory _emailValueObjectFactory;

        public CheckIfEmailExistsInRepositoryQueryFactory(IEmailValueObjectFactory emailValueObjectFactory)
        {
            _emailValueObjectFactory = emailValueObjectFactory;
        }

        public override CheckIfEmailExistsInRepositoryQuery Create(CultureInfo cultureInfo)
        {
            return new CheckIfEmailExistsInRepositoryQuery();
        }

        public CheckIfEmailExistsInRepositoryQuery Create(string parameter, CultureInfo cultureInfo)
        {
            var query = Create(cultureInfo);

            query.Email = _emailValueObjectFactory.Create(parameter, cultureInfo);

            return query;
        }
    }
}
