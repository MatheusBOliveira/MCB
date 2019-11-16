using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Patterns.CQRS.EventHandlers.Interfaces
{
    public interface IFailEventHandler<TEvent>
        where TEvent : EventBase
    {
        Task<EventReturn> HandleFailWith(TEvent message, CultureInfo culture, CancellationToken cancellationToken = default);
    }
}


