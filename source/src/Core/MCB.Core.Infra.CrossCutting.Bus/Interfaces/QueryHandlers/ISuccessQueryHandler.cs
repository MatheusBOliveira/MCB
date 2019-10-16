using MCB.Core.Infra.CrossCutting.Bus.ReturnObjects;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Bus.Interfaces.QueryHandlers
{
    public interface ISuccessQueryHandler<TQuery, TReturn>
        where TQuery : QueryBase
    {
        Task<QueryReturn<TReturn>> HandleSuccess(TQuery message, TReturn queryReturn, CancellationToken cancellationToken);
    }
}


