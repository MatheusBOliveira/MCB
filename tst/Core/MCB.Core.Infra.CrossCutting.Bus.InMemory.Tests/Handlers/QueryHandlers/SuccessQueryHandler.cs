using MCB.Core.Infra.CrossCutting.Bus.InMemory.Tests.Models;
using MCB.Core.Infra.CrossCutting.Bus.InMemory.Tests.Queries;
using MCB.Core.Infra.CrossCutting.Bus.Interfaces.QueryHandlers;
using MCB.Core.Infra.CrossCutting.Bus.ReturnObjects;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Bus.InMemory.Tests.Handlers.QueryHandlers
{
    public class SuccessQueryHandler
        : IStartWithQueryHandler<SuccessQuery, Customer>,
        IQueryHandler<SuccessQuery, Customer>,
        IEndWithQueryHandler<SuccessQuery, Customer>,
        ISuccessQueryHandler<SuccessQuery, Customer>
    {
        public async Task<QueryReturn<Customer>> HandleStartWith(SuccessQuery message, Customer queryReturn, CancellationToken cancellationToken)
        {
            var newId = Guid.NewGuid();

            var returnObject = new QueryReturn<Customer>(
                true,
                true,
                new Customer()
                {
                    Id = newId,
                    Name = "Marcelo Castelo Branco",
                    EmailAddress = "Email to be replaced"
                });

            return await Task.FromResult(returnObject);
        }

        public async Task<QueryReturn<Customer>> Handle(SuccessQuery message, Customer queryReturn, CancellationToken cancellationToken)
        {
            queryReturn.EmailAddress = "marcelo.castelo@outlook.com";

            var returnObject = new QueryReturn<Customer>(
                true,
                true,
                queryReturn);

            return await Task.FromResult(returnObject);
        }

        public async Task<QueryReturn<Customer>> HandleEndWith(SuccessQuery message, Customer queryReturn, CancellationToken cancellationToken)
        {
            queryReturn.Roles.Add("admin");

            var returnObject = new QueryReturn<Customer>(
                true,
                true,
                queryReturn);

            return await Task.FromResult(returnObject);
        }

        public async Task<QueryReturn<Customer>> HandleSuccess(SuccessQuery message, Customer queryReturn, CancellationToken cancellationToken)
        {
            var returnObject = new QueryReturn<Customer>(
                true,
                true,
                queryReturn);

            return await Task.FromResult(returnObject);
        }
    }
}


