using MCB.Core.Infra.CrossCutting.Bus.ReturnObjects;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Bus.Interfaces.EventHandlers
{
    public interface IEndWithEventHandler<TEvent>
        : IDisposable
        where TEvent : EventBase
    {
        Task<EventReturn> HandleEndWith(TEvent message, CancellationToken cancellationToken);
    }
}


