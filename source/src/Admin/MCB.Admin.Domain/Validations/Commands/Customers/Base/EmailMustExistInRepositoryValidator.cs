using MCB.Admin.Domain.Specifications.Commands.Customers.Base.Interfaces;
using MCB.Admin.Domain.Validations.Commands.Customers.Base.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.Specification;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Admin.Domain.Validations.Commands.Customers.Base
{
    public class EmailMustExistInRepositoryValidator
        : Validator<string>,
        IEmailMustExistInRepositoryValidator
    {
        public EmailMustExistInRepositoryValidator(
            IEmailMustExistsInRepositorySpecification emailMustExistsInRepositorySpecification)
        {
            AddSpecification(emailMustExistsInRepositorySpecification);
        }
    }
}
