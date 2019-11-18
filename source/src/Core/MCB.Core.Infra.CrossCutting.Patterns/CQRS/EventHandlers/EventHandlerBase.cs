using MCB.Core.Infra.CrossCutting.Patterns.CQRS.EventHandlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Core.Infra.CrossCutting.Patterns.CQRS.EventHandlers
{
    public abstract class EventHandlerBase
        : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
