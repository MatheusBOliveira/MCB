using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Patterns.CQRS.EventHandlers.Interfaces
{
    public interface IEndWithEventHandler<TEvent>
        : IDisposable
        where TEvent : EventBase
    {
        Task<EventReturn> HandleEndWith(TEvent message, CultureInfo culture, CancellationToken cancellationToken = default);
    }
}


