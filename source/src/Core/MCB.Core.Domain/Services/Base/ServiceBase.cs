using MCB.Core.Domain.Services.Interfaces.Base;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Saga.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Core.Domain.Services.Base
{
    public abstract class ServiceBase
        : IServiceBase
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

        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
