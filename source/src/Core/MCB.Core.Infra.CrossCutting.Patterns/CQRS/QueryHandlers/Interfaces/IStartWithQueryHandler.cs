using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Queries;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Queries.Interfaces;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Patterns.CQRS.QueryHandlers.Interfaces
{
    public interface IStartWithQueryHandler<TQuery, TReturn>
        where TQuery : IQuery
    {
        Task<QueryReturn<TReturn>> HandleStartWith(TQuery message, TReturn queryReturn, CultureInfo culture, CancellationToken cancellationToken = default);
    }
}


