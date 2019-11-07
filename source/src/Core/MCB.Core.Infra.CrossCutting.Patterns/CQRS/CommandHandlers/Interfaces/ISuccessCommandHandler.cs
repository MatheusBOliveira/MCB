using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Patterns.CQRS.CommandHandlers.Interfaces
{
    public interface ISuccessCommandHandler<TCommand, TReturn>
        : IDisposable
        where TCommand : CommandBase
    {
        Task<CommandReturn<TReturn>> HandleSuccess(TCommand message, TReturn returnObject, CancellationToken cancellationToken = default);
    }
}


