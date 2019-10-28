using MCB.Admin.Domain.Queries.Customers;
using MCB.Core.Infra.CrossCutting.Patterns.Factory.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Admin.Domain.Factories.Queries.Customers.Interfaces
{
    public interface ICheckIfEmailExistsInRepositoryQueryFactory
        : IFactory<CheckIfEmailExistsInRepositoryQuery>,
        IFactoryWithParameter<CheckIfEmailExistsInRepositoryQuery, string>
    {

    }
}
