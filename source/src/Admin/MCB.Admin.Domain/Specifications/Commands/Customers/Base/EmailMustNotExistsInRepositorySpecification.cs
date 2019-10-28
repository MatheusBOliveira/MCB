using MCB.Admin.Domain.Factories.Queries.Customers.Interfaces;
using MCB.Admin.Domain.Queries.Customers;
using MCB.Admin.Domain.Specifications.Commands.Customers.Base.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Saga.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MCB.Admin.Domain.Specifications.Commands.Customers.Base
{
    public class EmailMustNotExistsInRepositorySpecification
        : IEmailMustNotExistsInRepositorySpecification
    {
        private readonly ISagaManager _sagaManager;
        private readonly ICheckIfEmailExistsInRepositoryQueryFactory _checkIfEmailExistsInRepositoryQueryFactory;

        public EmailMustNotExistsInRepositorySpecification(
            ISagaManager sagaManager,
            ICheckIfEmailExistsInRepositoryQueryFactory checkIfEmailExistsInRepositoryQueryFactory)
        {
            _sagaManager = sagaManager;
            _checkIfEmailExistsInRepositoryQueryFactory = checkIfEmailExistsInRepositoryQueryFactory;
        }

        public string ErrorCode => "";

        public async Task<bool> IsSatisfiedBy(string entity)
        {
            var checkIfEmailExistsQuery = _checkIfEmailExistsInRepositoryQueryFactory.Create(entity);

            var queryReturn = await _sagaManager.GetQuery<CheckIfEmailExistsInRepositoryQuery, bool>
                (checkIfEmailExistsQuery, new System.Threading.CancellationToken());

            return !queryReturn.ReturnObject;
        }
    }
}
