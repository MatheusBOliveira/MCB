using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Queries;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Queries.Interfaces;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Patterns.CQRS.QueryHandlers.Interfaces
{
    public interface IFailQueryHandler<TQuery, TReturn>
        where TQuery : IQuery
    {
        Task<QueryReturn<TReturn>> HandleFail(TQuery message, TReturn queryReturn, CultureInfo culture, CancellationToken cancellationToken = default);
    }
}


