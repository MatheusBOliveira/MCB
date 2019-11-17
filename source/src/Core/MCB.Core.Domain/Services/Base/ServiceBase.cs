using MCB.Core.Domain.Services.Interfaces.Base;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Notifications;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Saga.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.Specification;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MCB.Core.Domain.Services.Base
{
    public abstract class ServiceBase
        : IService
    {
        private readonly ISagaManager _sagaManager;

        public ISagaManager SagaManager
        {
            get
            {
                return _sagaManager;
            }
        }

        public ServiceBase(ISagaManager sagaManager)
        {
            _sagaManager = sagaManager;
        }

        protected void NotifyValidationErrors(ValidationResult validationResult, CultureInfo culture)
        {
            foreach (var error in validationResult.ValidationMessageErrors)
                SagaManager.SendDomainNotification(
                    new DomainNotification(
                        error.Code,
                        error.DefaultDescription,
                        Infra.CrossCutting.Patterns.CQRS.Notifications.Enums.DomainNotificationTypeEnum.Error),
                    culture,
                    new System.Threading.CancellationToken());
        }

        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
