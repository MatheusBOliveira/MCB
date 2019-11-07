using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Queries.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Admin.Domain.Queries.Applications.Interfaces
{
    public interface IGetApplicationsByCustomerEmailAddressQuery
        : IQuery
    {
    }
}
