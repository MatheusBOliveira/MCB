using MCB.Core.Infra.CrossCutting.Patterns.Tests.Events;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.EventHandlers.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Patterns.Tests.Handlers.EventHandlers
{
    public class SuccessEventHandler
        : IStartWithEventHandler<SuccessEvent>,
        IEventHandler<SuccessEvent>,
        IEndWithEventHandler<SuccessEvent>,
        ISuccessEventHandler<SuccessEvent>
    {
        public async Task<EventReturn> HandleStartWith(SuccessEvent message, CancellationToken cancellationToken = default)
        {
            InMemorySagaManagerTest.EventSuccessMessageList.Add("HandleStartWith");

            return await Task.FromResult(
                new EventReturn(true, true));
        }
        public async Task<EventReturn> Handle(SuccessEvent message, CancellationToken cancellationToken = default)
        {
            InMemorySagaManagerTest.EventSuccessMessageList.Add("Handle");

            return await Task.FromResult(
                new EventReturn(true, true));
        }
        public async Task<EventReturn> HandleEndWith(SuccessEvent message, CancellationToken cancellationToken = default)
        {
            InMemorySagaManagerTest.EventSuccessMessageList.Add("HandleEndWith");

            return await Task.FromResult(
                new EventReturn(true, true));
        }
        public async Task<EventReturn> HandleSuccess(SuccessEvent message, CancellationToken cancellationToken = default)
        {
            InMemorySagaManagerTest.EventSuccessMessageList.Add("HandleSuccess");

            return await Task.FromResult(
                new EventReturn(true, true));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}


