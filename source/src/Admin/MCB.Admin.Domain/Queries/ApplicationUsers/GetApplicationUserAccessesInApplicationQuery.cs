using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MCB.Admin.Domain.Queries.ApplicationUsers
{
    public class GetApplicationUserAccessesInApplicationQuery
        : QueryBase
    {
        public string CustomerEmailAddress { get; set; }

        public override async Task<bool> IsValid()
        {
            return await Task.FromResult(true);
        }
    }
}
