using MCB.Core.Infra.CrossCutting.Bus.ReturnObjects;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Bus.Interfaces.CommandHandlers
{
    public interface IFailCommandHandler<TCommand, TReturn>
        where TCommand : CommandBase
    {
        Task<CommandReturn<TReturn>> HandleFailWith(TCommand message, TReturn returnObject, CancellationToken cancellationToken);
    }
}


