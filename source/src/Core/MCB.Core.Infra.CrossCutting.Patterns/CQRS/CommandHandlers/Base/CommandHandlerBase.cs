﻿using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Saga.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

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
