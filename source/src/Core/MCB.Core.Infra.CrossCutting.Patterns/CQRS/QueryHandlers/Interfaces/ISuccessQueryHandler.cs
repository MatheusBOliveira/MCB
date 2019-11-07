using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Patterns.CQRS.QueryHandlers.Interfaces
{
    public interface ISuccessQueryHandler<TQuery, TReturn>
        where TQuery : QueryBase
    {
        Task<QueryReturn<TReturn>> HandleSuccess(TQuery message, TReturn queryReturn, CancellationToken cancellationToken = default);
    }
}


