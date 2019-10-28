using MCB.Core.Infra.CrossCutting.Patterns.Specification.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Admin.Domain.Validations.Commands.Customers.Base.Interfaces
{
    public interface IEmailMustNotExistInRepositoryValidator
        : IValidator<string>
    {
    }
}
