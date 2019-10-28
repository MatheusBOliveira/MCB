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

        public CustomerCommandHandler(
            ISagaManager sagaManager,
            ICryptography cryptography,
            IActiveCustomerCommandValidator activeCustomerCommandValidator
            ) 
            : base(sagaManager)
        {
            _cryptography = cryptography;
            _activeCustomerCommandValidator = activeCustomerCommandValidator;
        }

        public async Task<CommandReturn<bool>> Handle(ActiveCustomerCommand message, bool returnObject, CancellationToken cancellationToken)
        {
            var commandReturn = new CommandReturn<bool>(returnObject);

            #region Validation
            var isValid = await ValidateCommand(message, returnObject, _activeCustomerCommandValidator);
            if (!isValid)
                return await Task.FromResult(new CommandReturn<bool>(returnObject, false, false));
            #endregion

            #region Business Process

            #endregion

            #region Notifications

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
