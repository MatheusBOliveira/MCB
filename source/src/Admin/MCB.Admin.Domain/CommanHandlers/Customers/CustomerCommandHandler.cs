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
using MCB.Admin.Domain.Validations.Commands.Customers.ActiveCustomerCommands.Interfaces;
using MCB.Admin.Domain.Factories.DomainModels.Interfaces;
using MCB.Admin.Domain.Factories.Events.Customers.Interfaces;
using MCB.Admin.Domain.DomainModels;
using MCB.Admin.Domain.Adapters.Events.Interfaces;

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

        private readonly IActiveCustomerCommandValidator _activeCustomerCommandValidator;

        private readonly ICustomerActivationFailEventAdapter _customerActivationFailEventAdapter;

        private readonly ICustomerFactory _customerFactory;
        private readonly ICustomerActivatedEventFactory _customerActivatedEventFactory;
        private readonly ICustomerActivationFailEventFactory _customerActivationFailEventFactory;

        public CustomerCommandHandler(
            ISagaManager sagaManager,
            ICryptography cryptography,
            IActiveCustomerCommandValidator activeCustomerCommandValidator,

            ICustomerActivationFailEventAdapter customerActivationFailEventAdapter,

            ICustomerFactory customerFactory,
            ICustomerActivatedEventFactory customerActivatedEventFactory,
            ICustomerActivationFailEventFactory customerActivationFailEventFactory
            ) 
            : base(sagaManager)
        {
            _cryptography = cryptography;

            _activeCustomerCommandValidator = activeCustomerCommandValidator;

            _customerActivationFailEventAdapter = customerActivationFailEventAdapter;

            _customerFactory = customerFactory;
            _customerActivatedEventFactory = customerActivatedEventFactory;
            _customerActivationFailEventFactory = customerActivationFailEventFactory;
        }

        public async Task<CommandReturn<bool>> Handle(ActiveCustomerCommand message, bool returnObject, CancellationToken cancellationToken)
        {
            var commandReturn = new CommandReturn<bool>(returnObject);
            var customer = _customerFactory.Create(message);

            #region Validation
            var isValid = await ValidateCommand(message, returnObject, _activeCustomerCommandValidator);
            if (!isValid)
            {
                // Raise failed Event
                var customerActivationFailEvent = _customerActivationFailEventAdapter.Adapt(
                    _customerActivationFailEventFactory.Create((customer, message.Username)),
                    message);

                await SagaManager.SendEvent(customerActivationFailEvent, cancellationToken);

                return await Task.FromResult(new CommandReturn<bool>(returnObject, false, false));
            }
            #endregion

            #region Business Process
            customer.ActivableInfo.Activate(message.Username);
            #endregion

            #region Notifications
            var customerActivatedEvent = _customerActivatedEventFactory.Create((customer, message.Username));
            await SagaManager.SendEvent(customerActivatedEvent, cancellationToken);
            #endregion

            commandReturn.Success = true;
            commandReturn.Continue = false;

            return await Task.FromResult(commandReturn);
        }


        public async Task<CommandReturn<bool>> Handle(InactiveCustomerCommand message, bool returnObject, CancellationToken cancellationToken)
        {
            var commandReturn = new CommandReturn<bool>(returnObject);



            return await Task.FromResult(commandReturn);
        }
        public async Task<CommandReturn<bool>> Handle(RegisterNewCustomerCommand message, bool returnObject, CancellationToken cancellationToken)
        {
            var commandReturn = new CommandReturn<bool>(returnObject);



            return await Task.FromResult(commandReturn);
        }
        public async Task<CommandReturn<bool>> Handle(RemoveCustomerCommand message, bool returnObject, CancellationToken cancellationToken)
        {
            var commandReturn = new CommandReturn<bool>(returnObject);



            return await Task.FromResult(commandReturn);
        }
    }
}
