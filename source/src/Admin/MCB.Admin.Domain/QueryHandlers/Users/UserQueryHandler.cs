using MCB.Admin.Domain.DomainModels;
using MCB.Admin.Domain.Queries.Users;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Queries;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.QueryHandlers.Base;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.QueryHandlers.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Saga.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MCB.Admin.Domain.QueryHandlers.Users
{
    public class UserQueryHandler
        : QueryHandlerBase,
        IQueryHandler<GetApplicationUserAccessesInApplicationQuery, List<ApplicationUser>>,
        IQueryHandler<GetApplicationUsersByAppTokenQuery, List<ApplicationUser>>
    {
        public UserQueryHandler(ISagaManager sagaManager) 
            : base(sagaManager)
        {
        }

        public async Task<QueryReturn<List<ApplicationUser>>> Handle(GetApplicationUserAccessesInApplicationQuery message, List<ApplicationUser> queryReturn, CancellationToken cancellationToken = default)
        {
            var query = new QueryReturn<List<ApplicationUser>>();



            return await Task.FromResult(query);
        }

        public async Task<QueryReturn<List<ApplicationUser>>> Handle(GetApplicationUsersByAppTokenQuery message, List<ApplicationUser> queryReturn, CancellationToken cancellationToken = default)
        {
            var query = new QueryReturn<List<ApplicationUser>>();



            return await Task.FromResult(query);
        }
    }
}
