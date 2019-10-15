using MCB.Core.Infra.CrossCutting.Bus.ReturnObjects;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Commands;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Notifications;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Bus.Interfaces
{
    public interface IBus
    {
        Task<QueryReturn<TReturn>> GetQuery<TQuery, TReturn>(TQuery query, CancellationToken cancellationToken)
            where TQuery : QueryBase;
        Task<CommandReturn<TReturn>> SendCommand<TCommand, TReturn>(TCommand command, CancellationToken cancellationToken) 
            where TCommand : CommandBase;
        Task<EventReturn> SendEvent<TEvent>(TEvent @event, CancellationToken cancellationToken) 
            where TEvent : EventBase;
        Task<EventReturn> SendDomainNotification(DomainNotification domainNotification, CancellationToken cancellationToken);
    }
}


