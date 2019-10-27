using MCB.Core.Application.AppServices.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Saga.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Core.Application.AppServices.Base
{
    public abstract class AppServiceBase
        : IAppService
    {
        // Fields
        private readonly ISagaManager _sagaManager;

        // Properties
        public ISagaManager SagaManager
        {
            get
            {
                return _sagaManager;
            }
        }

        protected AppServiceBase(ISagaManager sagaManager)
        {
            _sagaManager = sagaManager;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
