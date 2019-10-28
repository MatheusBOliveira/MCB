using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Saga.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using MCB.Core.Infra.CrossCutting.Patterns.Specification.Interfaces;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Patterns.CQRS.CommandHandlers.Base
{
    public abstract class CommandHandlerBase
        : IDisposable
    {
        private readonly ISagaManager _sagaManager;

        protected ISagaManager SagaManager
        {
            get
            {
                return _sagaManager;
            }
        }

        protected CommandHandlerBase(
            ISagaManager sagaManager
            )
        {
            _sagaManager = sagaManager;
        }

        protected async Task<bool> ValidateCommand<TCommand, TReturn>(TCommand message, TReturn returnObject, IValidator<TCommand> validator)
            where TCommand : CommandBase
        {
            message.ValidationResult = await validator.Validate(message);

            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
        protected void NotifyValidationErrors(CommandBase message)
        {
            foreach (var error in message.ValidationResult.Errors)
                SagaManager.SendDomainNotification(new DomainNotification(message.MessageType, error.Code), new System.Threading.CancellationToken());
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
