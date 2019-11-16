using MCB.Admin.Domain.DomainModels;
using MCB.Core.Infra.CrossCutting.Patterns.Specification.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Admin.Domain.Validations.Applications.Interfaces
{
    public interface IApplicationIsValidForRegistrationValidation
        : IValidator<Application>
    {
    }
}
