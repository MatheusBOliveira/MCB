using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Patterns.CQRS.EventHandlers.Interfaces
{
    public interface ISuccessEventHandler<TEvent>
        : IDisposable
        where TEvent : EventBase
    {
        Task<EventReturn> HandleSuccess(TEvent message, CancellationToken cancellationToken = default);
    }
}


