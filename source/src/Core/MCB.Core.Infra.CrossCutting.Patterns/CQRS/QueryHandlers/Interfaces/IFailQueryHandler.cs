using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Patterns.CQRS.QueryHandlers.Interfaces
{
    public interface IFailQueryHandler<TQuery, TReturn>
        where TQuery : QueryBase
    {
        Task<QueryReturn<TReturn>> HandleFail(TQuery message, TReturn queryReturn, CancellationToken cancellationToken);
    }
}


