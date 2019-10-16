using MCB.Core.Infra.CrossCutting.Bus.InMemory.Tests.Events;
using MCB.Core.Infra.CrossCutting.Bus.Interfaces.EventHandlers;
using MCB.Core.Infra.CrossCutting.Bus.ReturnObjects;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Bus.InMemory.Tests.Handlers.EventHandlers
{
    public class FailEventHandler
        : IStartWithEventHandler<FailEvent>,
        IEventHandler<FailEvent>,
        IEndWithEventHandler<FailEvent>,
        IFailEventHandler<FailEvent>
    {
        public async Task<EventReturn> HandleStartWith(FailEvent message, CancellationToken cancellationToken)
        {
            InMemoryBusTest.EventFailMessageList.Add("HandleStartWith");

            return await Task.FromResult(
                new EventReturn(true, true));
        }
        public async Task<EventReturn> Handle(FailEvent message, CancellationToken cancellationToken)
        {
            InMemoryBusTest.EventFailMessageList.Add("Handle");

            return await Task.FromResult(
                new EventReturn(false, false));
        }
        public async Task<EventReturn> HandleEndWith(FailEvent message, CancellationToken cancellationToken)
        {
            InMemoryBusTest.EventFailMessageList.Add("HandleEndWith");

            return await Task.FromResult(
                new EventReturn(true, true));
        }
        public async Task<EventReturn> HandleFailWith(FailEvent message, CancellationToken cancellationToken)
        {
            InMemoryBusTest.EventFailMessageList.Add("HandleFailWith");

            return await Task.FromResult(
                new EventReturn(false, false));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}


