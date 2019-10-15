using MCB.Core.Infra.CrossCutting.Bus.ReturnObjects;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Commands;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Bus.Interfaces.CommandHandlers
{
    public interface ICommandHandler<TCommand, TReturn>
        : IDisposable
        where TCommand : CommandBase
    {
        Task<CommandReturn<TReturn>> Handle(TCommand message, TReturn returnObject, CancellationToken cancellationToken);
    }
}


