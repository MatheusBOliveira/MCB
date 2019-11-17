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
        // Domain Services
        private readonly ICustomerService _customerService;
        private readonly IUserService _userService;
        private readonly IApplicationService _applicationService;
        // Factories
        private readonly ICustomerFactory _customerFactory;
        private readonly IUserFactory _userFactory;
        private readonly IApplicationFactory _applicationFactory;

        public CustomerCommandHandler(
            ISagaManager sagaManager,
            IDomainNotificationHandler domainNotificationHandler,
            // Domain Services
            ICustomerService customerService,
            IUserService userService,
            IApplicationService applicationService,
            // Factories
            ICustomerFactory customerFactory,
            IUserFactory userFactory,
            IApplicationFactory applicationFactory
            )
            : base(sagaManager, domainNotificationHandler)
        {
            _customerService = customerService;
            _userService = userService;
            _applicationService = applicationService;

            _customerFactory = customerFactory;
            _userFactory = userFactory;
            _applicationFactory = applicationFactory;
        }

        public async Task<CommandReturn<bool>> Handle(ActiveCustomerCommand message, bool returnObject, CultureInfo culture, CancellationToken cancellationToken = default)
        {
            var commandReturn = new CommandReturn<bool>(returnObject);



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

            // Objects creations
            var customer = _customerFactory.Create(message, message.CultureInfo);
            var user = _userFactory.Create(message, message.CultureInfo);
            var application = _applicationFactory.Create(message, message.CultureInfo);

            // Business Process
            customer = await _customerService.RegisterNewCustomer(customer, message.Username, culture);
            user = await _userService.RegisterNewUser(user, customer, message.Username, culture);
            application = await _applicationService.RegisterNewApplication(application, customer, user, message.Username, culture);

            // Check Validations
            if (!customer.DomainModel.IsValid()
                || !user.DomainModel.IsValid()
                || !application.DomainModel.IsValid())
            {
                // Create and send fail event

                commandReturn.Success = false;
                commandReturn.ReturnObject = false;
                return await Task.FromResult(commandReturn);
            }

            // Create event success event

            commandReturn.Success = true;
            commandReturn.ReturnObject = true;
            return await Task.FromResult(commandReturn);
        }
        public async Task<CommandReturn<bool>> Handle(RemoveCustomerCommand message, bool returnObject, CultureInfo culture, CancellationToken cancellationToken = default)
        {
            var commandReturn = new CommandReturn<bool>(returnObject);



            return await Task.FromResult(commandReturn);
        }
    }
}
