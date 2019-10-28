using MCB.Admin.Domain.Commands.Customers;
using MCB.Admin.Domain.Validations.Commands.Customers.ActiveCustomerCommands.Interfaces;
using MCB.Admin.Domain.Validations.Commands.Customers.Base.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.Specification;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MCB.Admin.Domain.Validations.Commands.Customers.ActiveCustomerCommands
{
    public class ActiveCustomerCommandValidator
        : Validator<ActiveCustomerCommand>,
        IActiveCustomerCommandValidator
    {
        private readonly IEmailMustExistInRepositoryValidator _emailMustExistInRepositoryValidator;

        public ActiveCustomerCommandValidator(
            IEmailMustExistInRepositoryValidator emailMustExistInRepositoryValidator)
        {
            _emailMustExistInRepositoryValidator = emailMustExistInRepositoryValidator;
        }

        public async override Task<ValidationResult> Validate(ActiveCustomerCommand entity)
        {
            var validationResult = await base.Validate(entity);

            var emailMustExistsInRepositoryValidationResult = await _emailMustExistInRepositoryValidator.Validate(entity.Email?.EmailAddress);

            validationResult.Add(emailMustExistsInRepositoryValidationResult);

            return validationResult;
        }
    }
}
