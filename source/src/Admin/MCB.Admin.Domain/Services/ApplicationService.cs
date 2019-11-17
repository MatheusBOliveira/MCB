using MCB.Admin.Domain.DomainModels;
using MCB.Admin.Domain.Factories.DomainModels.Interfaces;
using MCB.Admin.Domain.Services.Interfaces;
using MCB.Admin.Domain.Validations.Applications.Interfaces;
using MCB.Core.Domain.Services.Base;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Saga.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace MCB.Admin.Domain.Services
{
    public class ApplicationService
        : ServiceBase,
        IApplicationService
    {
        private readonly IApplicationUserFactory _applicationUserFactory;
        private readonly IApplicationFunctionFactory _applicationFunctionFactory;
        private readonly IApplicationRoleFactory _applicationRoleFactory;

        private readonly IApplicationIsValidForRegistrationValidation _applicationIsValidForRegistrationValidation;

        public ApplicationService(
            ISagaManager sagaManager,
            IApplicationUserFactory applicationUserFactory,
            IApplicationFunctionFactory applicationFunctionFactory,
            IApplicationRoleFactory applicationRoleFactory,
            IApplicationIsValidForRegistrationValidation applicationIsValidForRegistrationValidation
            )
            : base(sagaManager)
        {
            _applicationUserFactory = applicationUserFactory;
            _applicationFunctionFactory = applicationFunctionFactory;
            _applicationRoleFactory = applicationRoleFactory;

            _applicationIsValidForRegistrationValidation = applicationIsValidForRegistrationValidation;
        }

        public async Task<Application> RegisterNewApplication(Application application, Customer customer, User user, string registrationUsername, CultureInfo culture)
        {
            application.DomainModel.ValidationResult = await _applicationIsValidForRegistrationValidation.Validate(application, culture);
            if (!application.DomainModel.IsValid())
            {
                NotifyValidationErrors(application.DomainModel.ValidationResult, culture);
                return await Task.FromResult(application);
            }

            application.RegisterNewApplication(customer, user, registrationUsername, _applicationUserFactory, _applicationFunctionFactory, _applicationRoleFactory, culture);

            return await Task.FromResult(application);
        }
    }
}
