using MCB.Admin.Domain.DomainModels;
using MCB.Admin.Domain.Validations.Users.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.Specification;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Admin.Domain.Validations.Users
{
    public class UserIsValidForRegistrationValidation
        : Validator<User>,
        IUserIsValidForRegistrationValidation
    {
    }
}
