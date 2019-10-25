using MCB.Admin.Domain.DomainModels;
using MCB.Admin.Domain.Queries.Customers;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Queries;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.QueryHandlers.Base;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.QueryHandlers.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Saga.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MCB.Admin.Domain.QueryHandlers.Customers
{
    public class CustomerQueryHandler
        : QueryHandlerBase,
        IQueryHandler<GetAllCustomersQuery, List<Customer>>,
        IQueryHandler<GetCustomerByEmailAddressQuery, Customer>,
        IQueryHandler<GetCustomersByNameQuery, List<Customer>>
    {
        public CustomerQueryHandler(ISagaManager sagaManager) 
            : base(sagaManager)
        {

        }

        public async Task<QueryReturn<List<Customer>>> Handle(GetAllCustomersQuery message, List<Customer> queryReturn, CancellationToken cancellationToken)
        {
            var query = new QueryReturn<List<Customer>>(queryReturn);



            return await Task.FromResult(query);
        }

        public async Task<QueryReturn<Customer>> Handle(GetCustomerByEmailAddressQuery message, Customer queryReturn, CancellationToken cancellationToken)
        {
            var query = new QueryReturn<Customer>(queryReturn);



            return await Task.FromResult(query);
        }

        public async Task<QueryReturn<List<Customer>>> Handle(GetCustomersByNameQuery message, List<Customer> queryReturn, CancellationToken cancellationToken)
        {
            var query = new QueryReturn<List<Customer>>(queryReturn);



            return await Task.FromResult(query);
        }
    }
}
