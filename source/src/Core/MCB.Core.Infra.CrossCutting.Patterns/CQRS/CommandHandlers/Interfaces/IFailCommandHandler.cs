using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using System.Threading;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Patterns.CQRS.CommandHandlers.Interfaces
{
    public interface IFailCommandHandler<TCommand, TReturn>
        where TCommand : CommandBase
    {
        Task<CommandReturn<TReturn>> HandleFailWith(TCommand message, TReturn returnObject, CancellationToken cancellationToken = default);
    }
}


