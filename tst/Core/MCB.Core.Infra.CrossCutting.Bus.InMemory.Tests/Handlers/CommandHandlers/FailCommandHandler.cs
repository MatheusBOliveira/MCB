using MCB.Core.Infra.CrossCutting.Bus.InMemory.Tests.Commands;
using MCB.Core.Infra.CrossCutting.Bus.InMemory.Tests.Events;
using MCB.Core.Infra.CrossCutting.Bus.Interfaces.CommandHandlers;
using MCB.Core.Infra.CrossCutting.Bus.ReturnObjects;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Bus.InMemory.Tests.Handlers.CommandHandlers
{
    public class FailCommandHandler
        : IStartWithCommandHandler<FailCommand, SuccessEvent>,
        ICommandHandler<FailCommand, SuccessEvent>,
        IEndWithCommandHandler<FailCommand, SuccessEvent>,
        IFailCommandHandler<FailCommand, SuccessEvent>
    {
        public async Task<CommandReturn<SuccessEvent>> HandleStartWith(FailCommand message, SuccessEvent returnObject, CancellationToken cancellationToken)
        {
            var newId = Guid.NewGuid();

            return await Task.FromResult(
                new CommandReturn<SuccessEvent>(true, true)
                {
                    ReturnObject = new SuccessEvent
                    {
                        AggregateId = newId,
                        Id = newId,
                        Name = "Name to be replaced",
                        EmailAddress = "Email to be replaced"
                    }
                });
        }
        public async Task<CommandReturn<SuccessEvent>> Handle(FailCommand message, SuccessEvent returnObject, CancellationToken cancellationToken)
        {
            returnObject.Name = message.Name;
            returnObject.EmailAddress = "New email to be replaced";

            return await Task.FromResult(
                new CommandReturn<SuccessEvent>(false, false)
                {
                    ReturnObject = returnObject
                });
        }
        public async Task<CommandReturn<SuccessEvent>> HandleEndWith(FailCommand message, SuccessEvent returnObject, CancellationToken cancellationToken)
        {
            returnObject.EmailAddress = message.EmailAddress;

            return await Task.FromResult(
                new CommandReturn<SuccessEvent>(true, true)
                {
                    ReturnObject = returnObject
                });
        }
        public async Task<CommandReturn<SuccessEvent>> HandleFailWith(FailCommand message, SuccessEvent returnObject, CancellationToken cancellationToken)
        {
            returnObject.EmailAddress = string.Empty;

            return await Task.FromResult(
                new CommandReturn<SuccessEvent>(false, false)
                {
                    ReturnObject = returnObject
                });
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}


