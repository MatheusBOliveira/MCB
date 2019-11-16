using MCB.Admin.Domain.Commands.Customers;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.CommandHandlers.Base;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Saga.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.CommandHandlers.Interfaces;
using MCB.Core.Infra.CrossCutting.Security.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using System.Threading;
using System.Threading.Tasks;
using MCB.Admin.Domain.Events.Customers;
using MCB.Admin.Domain.Factories.DomainModels.Interfaces;
using MCB.Admin.Domain.Factories.Events.Customers.Interfaces;
using MCB.Admin.Domain.DomainModels;
using MCB.Admin.Domain.Adapters.Events.Interfaces;
using MCB.Admin.Domain.Services.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.EventHandlers.Interfaces;
using MCB.Admin.Domain.Validations.Customers.Interfaces;
using System.Globalization;
using MCB.Admin.Domain.Validations.Users.Interfaces;
using MCB.Admin.Domain.Validations.Applications.Interfaces;

namespace MCB.Admin.Domain.CommanHandlers.Customers
{
    public class CustomerCommandHandler
        : CommandHandlerBase,
        ICommandHandler<ActiveCustomerCommand, bool>,
        ICommandHandler<InactiveCustomerCommand, bool>,
        ICommandHandler<RegisterNewCustomerCommand, bool>,
        ICommandHandler<RemoveCustomerCommand, bool>
    {
        private readonly ICryptography _cryptography;
        // Domain Services
        private readonly ICustomerService _customerService;
        // Adapters
        private readonly ICustomerActivationFailEventAdapter _customerActivationFailEventAdapter;
        // Factories
        private readonly ICustomerFactory _customerFactory;
        private readonly IUserFactory _userFactory;
        private readonly IApplicationFactory _applicationFactory;
        private readonly ICustomerActivatedEventFactory _customerActivatedEventFactory;
        private readonly ICustomerActivationFailEventFactory _customerActivationFailEventFactory;
        // Validations
        private readonly ICustomerIsValidForRegistrationValidation _customerIsValidForRegistrationValidation;
        private readonly IUserIsValidForRegistrationValidation _userIsValidForRegistrationValidation;
        private readonly IApplicationIsValidForRegistrationValidation _applicationIsValidForRegistrationValidation;

        public CustomerCommandHandler(
            ISagaManager sagaManager,
            IDomainNotificationHandler domainNotificationHandler,
            ICryptography cryptography,
            // Domain Services
            ICustomerService customerService,
            // Adapters
            ICustomerActivationFailEventAdapter customerActivationFailEventAdapter,
            // Factories
            ICustomerFactory customerFactory,
            IUserFactory userFactory,
            IApplicationFactory applicationFactory,
            ICustomerActivatedEventFactory customerActivatedEventFactory,
            ICustomerActivationFailEventFactory customerActivationFailEventFactory,
            // Validations
            ICustomerIsValidForRegistrationValidation customerIsValidForRegistrationValidation,
            IUserIsValidForRegistrationValidation userIsValidForRegistrationValidation,
            IApplicationIsValidForRegistrationValidation applicationIsValidForRegistrationValidation
            ) 
            : base(sagaManager, domainNotificationHandler)
        {
            _cryptography = cryptography;

            _customerService = customerService;
            _userFactory = userFactory;
            _applicationFactory = applicationFactory;

            _customerActivationFailEventAdapter = customerActivationFailEventAdapter;

            _customerFactory = customerFactory;
            _customerActivatedEventFactory = customerActivatedEventFactory;
            _customerActivationFailEventFactory = customerActivationFailEventFactory;

            _customerIsValidForRegistrationValidation = customerIsValidForRegistrationValidation;
            _userIsValidForRegistrationValidation = userIsValidForRegistrationValidation;
            _applicationIsValidForRegistrationValidation = applicationIsValidForRegistrationValidation;
        }

        public async Task<CommandReturn<bool>> Handle(ActiveCustomerCommand message, bool returnObject, CultureInfo culture, CancellationToken cancellationToken = default)
        {
            // Input
            var commandReturn = new CommandReturn<bool>(returnObject);
            var customer = _customerFactory.Create(message, message.CultureInfo);

            // Process
            _customerService.ActiveCustomer(customer);

            var success = HasErrors();
            if (success)
            {
                // Notifications
                var customerActivatedEvent = _customerActivatedEventFactory.Create((customer, message.Username), message.CultureInfo);
                await SagaManager.SendEvent(customerActivatedEvent, cancellationToken);
            }
            else
            {

            }


            // Return
            commandReturn.Success = success;

            return await Task.FromResult(commandReturn);
        }
        public async Task<CommandReturn<bool>> Handle(InactiveCustomerCommand message, bool returnObject, CultureInfo culture, CancellationToken cancellationToken = default)
        {
            var commandReturn = new CommandReturn<bool>(returnObject);



            return await Task.FromResult(commandReturn);
        }
        public async Task<CommandReturn<bool>> Handle(RegisterNewCustomerCommand message, bool returnObject, CultureInfo culture, CancellationToken cancellationToken = default)
        {
            var commandReturn = new CommandReturn<bool>(returnObject);
            var isValid = true;

            var customer = _customerFactory.Create(message, message.CultureInfo);
            var user = _userFactory.Create(message, message.CultureInfo);
            var application = _applicationFactory.Create(message, message.CultureInfo);

            #region Validations
            // Validate Customer
            customer.DomainModel.ValidationResult = await _customerIsValidForRegistrationValidation.Validate(customer, culture);
            if (!customer.DomainModel.IsValid())
            {
                isValid = false;
                NotifyValidationErrors(customer.DomainModel.ValidationResult);
            }
            // Validate User
            user.DomainModel.ValidationResult = await _userIsValidForRegistrationValidation.Validate(user, culture);
            if (!user.DomainModel.IsValid())
            {
                isValid = false;
                NotifyValidationErrors(user.DomainModel.ValidationResult);
            }
            // Validate Application
            application.DomainModel.ValidationResult = await _userIsValidForRegistrationValidation.Validate(application, culture);
            if (!application.DomainModel.IsValid())
            {
                isValid = false;
                NotifyValidationErrors(application.DomainModel.ValidationResult);
            }

            if (!isValid)
            {
                commandReturn.Success = false;
                return await Task.FromResult(commandReturn);
            }
            #endregion

            #region Business Process

            #endregion

            return await Task.FromResult(commandReturn);
        }
        public async Task<CommandReturn<bool>> Handle(RemoveCustomerCommand message, bool returnObject, CultureInfo culture, CancellationToken cancellationToken = default)
        {
            var commandReturn = new CommandReturn<bool>(returnObject);



            return await Task.FromResult(commandReturn);
        }
    }
}
