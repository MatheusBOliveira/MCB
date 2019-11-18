using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events.Interfaces;
using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Patterns.CQRS.EventHandlers.Interfaces
{
    public interface ISuccessEventHandler<TEvent>
        : IDisposable
        where TEvent : IEvent
    {
        Task<EventReturn> HandleSuccess(TEvent message, CultureInfo culture, CancellationToken cancellationToken = default);
    }
}


