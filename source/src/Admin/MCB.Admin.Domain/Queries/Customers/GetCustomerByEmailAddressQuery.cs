using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MCB.Admin.Domain.Queries.Customers
{
    public class GetCustomerByEmailAddressQuery
        : QueryBase
    {
        public string EmailAddress { get; set; }

        public override async Task<bool> IsValid()
        {
            return await Task.FromResult(true);
        }
    }
}
