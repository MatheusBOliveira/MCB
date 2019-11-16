using MCB.Admin.Domain.DomainModels;
using MCB.Admin.Domain.Validations.Applications.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.Specification;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Admin.Domain.Validations.Applications
{
    public class ApplicationIsValidForRegistrationValidation
        : Validator<Application>,
        IApplicationIsValidForRegistrationValidation
    {

    }
}
