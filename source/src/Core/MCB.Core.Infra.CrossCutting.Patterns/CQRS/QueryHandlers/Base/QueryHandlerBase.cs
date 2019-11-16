using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Notifications;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Queries;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Saga.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MCB.Core.Infra.CrossCutting.Patterns.CQRS.QueryHandlers.Base
{
    public abstract class QueryHandlerBase
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

        protected QueryHandlerBase(
            ISagaManager sagaManager
            )
        {
            _sagaManager = sagaManager;
        }

        protected void NotifyValidationErrors(QueryBase message, CultureInfo culture)
        {
            foreach (var error in message.ValidationResult.ValidationMessageErrors)
                SagaManager.SendDomainNotification(new DomainNotification(message.MessageType, error.Code, Notifications.Enums.DomainNotificationTypeEnum.Error), culture, new System.Threading.CancellationToken());
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
