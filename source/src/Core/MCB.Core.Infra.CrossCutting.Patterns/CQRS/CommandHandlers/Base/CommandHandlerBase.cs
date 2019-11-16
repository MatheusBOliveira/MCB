using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Saga.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using MCB.Core.Infra.CrossCutting.Patterns.Specification.Interfaces;
using System.Threading.Tasks;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.EventHandlers.Interfaces;
using System.Globalization;
using MCB.Core.Infra.CrossCutting.Patterns.Specification;

namespace MCB.Core.Infra.CrossCutting.Patterns.CQRS.CommandHandlers.Base
{
    public abstract class CommandHandlerBase
        : IDisposable
    {
        private readonly ISagaManager _sagaManager;
        private readonly IDomainNotificationHandler _domainNotificationHandler;
        protected ISagaManager SagaManager
        {
            get
            {
                return _sagaManager;
            }
        }

        protected CommandHandlerBase(
            ISagaManager sagaManager,
            IDomainNotificationHandler domainNotificationHandler
            )
        {
            _sagaManager = sagaManager;
            _domainNotificationHandler = domainNotificationHandler;
        }

        //protected async Task<bool> ValidateCommand<TCommand, TReturn>(TCommand message, TReturn returnObject, IValidator<TCommand> validator, CultureInfo culture)
        //    where TCommand : CommandBase
        //{
        //    message.ValidationResult = await validator.Validate(message, culture);

        //    if (!message.IsValid())
        //    {
        //        NotifyValidationErrors(message);
        //        return await Task.FromResult(false);
        //    }

        //    return await Task.FromResult(true);
        //}
        protected void NotifyValidationErrors(ValidationResult validationResult)
        {
            foreach (var error in validationResult.ValidationMessageErrors)
                SagaManager.SendDomainNotification(
                    new DomainNotification(
                        error.Code,
                        error.DefaultDescription, 
                        Notifications.Enums.DomainNotificationTypeEnum.Error), 
                    new System.Threading.CancellationToken());
        }
        protected bool HasErrors()
        {
            return _domainNotificationHandler.HasErrors();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
