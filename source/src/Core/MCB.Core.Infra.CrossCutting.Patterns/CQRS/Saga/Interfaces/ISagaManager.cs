using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Notifications;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Queries;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Queries.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Patterns.CQRS.Saga.Interfaces
{
    public interface ISagaManager
    {
        Task<QueryReturn<TReturn>> GetQuery<TQuery, TReturn>(TQuery query, CultureInfo culture, CancellationToken cancellationToken = default)
            where TQuery : IQuery;
        Task<CommandReturn<TReturn>> SendCommand<TCommand, TReturn>(TCommand command, CultureInfo culture, CancellationToken cancellationToken = default)
            where TCommand : CommandBase;
        Task<EventReturn> SendEvent<TEvent>(TEvent @event, CultureInfo culture, CancellationToken cancellationToken = default)
            where TEvent : EventBase;
        Task<EventReturn> SendDomainNotification(DomainNotification domainNotification, CultureInfo culture, CancellationToken cancellationToken = default);
    }
}
