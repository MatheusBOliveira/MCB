using MCB.Admin.Domain.DomainModels;
using MCB.Admin.Domain.Services.Interfaces;
using MCB.Admin.Domain.Validations.Users;
using MCB.Core.Domain.Services.Base;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Saga.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace MCB.Admin.Domain.Services
{
    public class UserService
        : ServiceBase,
        IUserService
    {
        private readonly UserIsValidForRegistrationValidation _userIsValidForRegistrationValidation;

        public UserService(
            ISagaManager sagaManager,
            UserIsValidForRegistrationValidation userIsValidForRegistrationValidation
            ) 
            : base(sagaManager)
        {
            _userIsValidForRegistrationValidation = userIsValidForRegistrationValidation;
        }

        public async Task<User> RegisterNewUser(User user, Customer customer, string registrationUsername, CultureInfo culture)
        {
            user.DomainModel.ValidationResult = await _userIsValidForRegistrationValidation.Validate(user, culture);
            if (!user.DomainModel.IsValid())
            {
                NotifyValidationErrors(user.DomainModel.ValidationResult, culture);
                return await Task.FromResult(user);
            }

            user.RegisterNewUser(customer, registrationUsername, culture);

            return await Task.FromResult(user);
        }
    }
}
