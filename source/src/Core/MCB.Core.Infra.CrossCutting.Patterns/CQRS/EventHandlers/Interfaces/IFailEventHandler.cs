using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events.Interfaces;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Patterns.CQRS.EventHandlers.Interfaces
{
    public interface IFailEventHandler<TEvent>
        where TEvent : IEvent
    {
        Task<EventReturn> HandleFailWith(TEvent message, CultureInfo culture, CancellationToken cancellationToken = default);
    }
}


