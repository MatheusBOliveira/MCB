using MCB.Core.Infra.CrossCutting.Bus.InMemory.Tests.Models;
using MCB.Core.Infra.CrossCutting.Bus.InMemory.Tests.Queries;
using MCB.Core.Infra.CrossCutting.Bus.Interfaces.QueryHandlers;
using MCB.Core.Infra.CrossCutting.Bus.ReturnObjects;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Bus.InMemory.Tests.Handlers.QueryHandlers
{
    public class FailQueryHandler
        : IStartWithQueryHandler<FailQuery, Customer>,
        IQueryHandler<FailQuery, Customer>,
        IEndWithQueryHandler<FailQuery, Customer>,
        IFailQueryHandler<FailQuery, Customer>
    {
        public async Task<QueryReturn<Customer>> HandleStartWith(FailQuery message, Customer queryReturn, CancellationToken cancellationToken)
        {
            var newId = Guid.NewGuid();

            var returnObject = new QueryReturn<Customer>(
                true,
                true,
                new Customer()
                {
                    Id = newId,
                    Name = "Name to be replaced",
                    EmailAddress = "Email to be replaced"
                });

            return await Task.FromResult(returnObject);
        }

        public async Task<QueryReturn<Customer>> Handle(FailQuery message, Customer queryReturn, CancellationToken cancellationToken)
        {
            queryReturn.Name = "Marcelo Castelo Branco";
            queryReturn.EmailAddress = "marcelo.castelo@outlook.com";

            var returnObject = new QueryReturn<Customer>(
                false,
                false,
                queryReturn);

            return await Task.FromResult(returnObject);
        }

        public async Task<QueryReturn<Customer>> HandleEndWith(FailQuery message, Customer queryReturn, CancellationToken cancellationToken)
        {
            queryReturn.Name = string.Empty;
            queryReturn.EmailAddress = string.Empty;

            var returnObject = new QueryReturn<Customer>(
                true,
                true,
                queryReturn);

            return await Task.FromResult(returnObject);
        }

        public async Task<QueryReturn<Customer>> HandleFail(FailQuery message, Customer queryReturn, CancellationToken cancellationToken)
        {
            queryReturn.Roles.Clear();

            var returnObject = new QueryReturn<Customer>(
                false,
                false,
                queryReturn);

            return await Task.FromResult(returnObject);
        }
    }
}


