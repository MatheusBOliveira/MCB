using MCB.Core.Infra.CrossCutting.Patterns.Tests.Commands;
using MCB.Core.Infra.CrossCutting.Patterns.Tests.Events;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.CommandHandlers.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;

namespace MCB.Core.Infra.CrossCutting.Patterns.Tests.Handlers.CommandHandlers
{
    public class FailCommandHandler
        : IStartWithCommandHandler<FailCommand, SuccessEvent>,
        ICommandHandler<FailCommand, SuccessEvent>,
        IEndWithCommandHandler<FailCommand, SuccessEvent>,
        IFailCommandHandler<FailCommand, SuccessEvent>
    {
        public async Task<CommandReturn<SuccessEvent>> HandleStartWith(FailCommand message, SuccessEvent returnObject, CultureInfo culture, CancellationToken cancellationToken = default)
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
        public async Task<CommandReturn<SuccessEvent>> Handle(FailCommand message, SuccessEvent returnObject, CultureInfo culture, CancellationToken cancellationToken = default)
        {
            returnObject.Name = message.Name;
            returnObject.EmailAddress = "New email to be replaced";

            return await Task.FromResult(
                new CommandReturn<SuccessEvent>(false, false)
                {
                    ReturnObject = returnObject
                });
        }
        public async Task<CommandReturn<SuccessEvent>> HandleEndWith(FailCommand message, SuccessEvent returnObject, CultureInfo culture, CancellationToken cancellationToken = default)
        {
            returnObject.EmailAddress = message.EmailAddress;

            return await Task.FromResult(
                new CommandReturn<SuccessEvent>(true, true)
                {
                    ReturnObject = returnObject
                });
        }
        public async Task<CommandReturn<SuccessEvent>> HandleFailWith(FailCommand message, SuccessEvent returnObject, CultureInfo culture, CancellationToken cancellationToken = default)
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


