using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events.Interfaces;
using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Patterns.CQRS.EventHandlers.Interfaces
{
    public interface IStartWithEventHandler<TEvent>
        : IDisposable
        where TEvent : IEvent
    {
        Task<EventReturn> HandleStartWith(TEvent message, CultureInfo culture, CancellationToken cancellationToken = default);
    }
}


