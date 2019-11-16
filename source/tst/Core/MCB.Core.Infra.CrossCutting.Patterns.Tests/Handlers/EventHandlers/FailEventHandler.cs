using MCB.Core.Infra.CrossCutting.Patterns.Tests.Events;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.EventHandlers.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;

namespace MCB.Core.Infra.CrossCutting.Patterns.Tests.Handlers.EventHandlers
{
    public class FailEventHandler
        : IStartWithEventHandler<FailEvent>,
        IEventHandler<FailEvent>,
        IEndWithEventHandler<FailEvent>,
        IFailEventHandler<FailEvent>
    {
        public async Task<EventReturn> HandleStartWith(FailEvent message, CultureInfo culture, CancellationToken cancellationToken = default)
        {
            InMemorySagaManagerTest.EventFailMessageList.Add("HandleStartWith");

            return await Task.FromResult(
                new EventReturn(true, true));
        }
        public async Task<EventReturn> Handle(FailEvent message, CultureInfo culture, CancellationToken cancellationToken = default)
        {
            InMemorySagaManagerTest.EventFailMessageList.Add("Handle");

            return await Task.FromResult(
                new EventReturn(false, false));
        }
        public async Task<EventReturn> HandleEndWith(FailEvent message, CultureInfo culture, CancellationToken cancellationToken = default)
        {
            InMemorySagaManagerTest.EventFailMessageList.Add("HandleEndWith");

            return await Task.FromResult(
                new EventReturn(true, true));
        }
        public async Task<EventReturn> HandleFailWith(FailEvent message, CultureInfo culture, CancellationToken cancellationToken = default)
        {
            InMemorySagaManagerTest.EventFailMessageList.Add("HandleFailWith");

            return await Task.FromResult(
                new EventReturn(false, false));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}


