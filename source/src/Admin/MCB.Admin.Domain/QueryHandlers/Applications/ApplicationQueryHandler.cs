using MCB.Admin.Domain.DomainModels;
using MCB.Admin.Domain.Queries.Applications;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Queries;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.QueryHandlers.Base;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.QueryHandlers.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Saga.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MCB.Admin.Domain.QueryHandlers.Applications
{
    public class ApplicationQueryHandler
        : QueryHandlerBase,
        IQueryHandler<GetApplicationsByCustomerEmailAddressQuery, List<Application>>
    {
        public ApplicationQueryHandler(ISagaManager sagaManager) 
            : base(sagaManager)
        {

        }

        public async Task<QueryReturn<List<Application>>> Handle(GetApplicationsByCustomerEmailAddressQuery message, List<Application> queryReturn, CancellationToken cancellationToken = default)
        {
            var query = new QueryReturn<List<Application>>();



            return await Task.FromResult(query);
        }
    }
}
