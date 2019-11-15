using MCB.Core.Infra.CrossCutting.Patterns.CQRS.CommandHandlers.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.EventHandlers.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Notifications;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Queries;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Queries.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.QueryHandlers.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Saga.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Patterns.CQRS.Saga.Base
{
    public abstract class SagaManagerBase
        : ISagaManager
    {
        protected IServiceProvider ServiceProvider { get; }

        protected SagaManagerBase(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        protected IEnumerable<IStartWithCommandHandler<TCommand, TReturn>> GetStartWithCommandHandlers<TCommand, TReturn>()
            where TCommand : CommandBase
        {
            return (IEnumerable<IStartWithCommandHandler<TCommand, TReturn>>)
                ServiceProvider.GetServices(typeof(IStartWithCommandHandler<TCommand, TReturn>));
        }
        protected IEnumerable<IEndWithCommandHandler<TCommand, TReturn>> GetEndWithCommandHandlers<TCommand, TReturn>()
            where TCommand : CommandBase
        {
            return (IEnumerable<IEndWithCommandHandler<TCommand, TReturn>>)
                ServiceProvider.GetServices(typeof(IEndWithCommandHandler<TCommand, TReturn>));
        }
        protected IEnumerable<ISuccessCommandHandler<TCommand, TReturn>> GetSuccessCommandHandlers<TCommand, TReturn>()
            where TCommand : CommandBase
        {
            return (IEnumerable<ISuccessCommandHandler<TCommand, TReturn>>)
                ServiceProvider.GetServices(typeof(ISuccessCommandHandler<TCommand, TReturn>));
        }
        protected IEnumerable<IFailCommandHandler<TCommand, TReturn>> GetFailCommandHandlers<TCommand, TReturn>()
            where TCommand : CommandBase
        {
            return (IEnumerable<IFailCommandHandler<TCommand, TReturn>>)
                ServiceProvider.GetServices(typeof(IFailCommandHandler<TCommand, TReturn>));
        }
        protected IEnumerable<ICommandHandler<TCommand, TReturn>> GetCommandHandlers<TCommand, TReturn>()
            where TCommand : CommandBase
        {
            return (IEnumerable<ICommandHandler<TCommand, TReturn>>)
                ServiceProvider.GetServices(typeof(ICommandHandler<TCommand, TReturn>));
        }

        protected IEnumerable<IStartWithQueryHandler<TQuery, TReturn>> GetStartWithQueryHandlers<TQuery, TReturn>()
            where TQuery : IQuery
        {
            return (IEnumerable<IStartWithQueryHandler<TQuery, TReturn>>)
                ServiceProvider.GetServices(typeof(IStartWithQueryHandler<TQuery, TReturn>));
        }
        protected IEnumerable<IEndWithQueryHandler<TQuery, TReturn>> GetEndWithQueryHandlers<TQuery, TReturn>()
            where TQuery : IQuery
        {
            return (IEnumerable<IEndWithQueryHandler<TQuery, TReturn>>)
                ServiceProvider.GetServices(typeof(IEndWithQueryHandler<TQuery, TReturn>));
        }
        protected IEnumerable<ISuccessQueryHandler<TQuery, TReturn>> GetSuccessQueryHandlers<TQuery, TReturn>()
            where TQuery : IQuery
        {
            return (IEnumerable<ISuccessQueryHandler<TQuery, TReturn>>)
                ServiceProvider.GetServices(typeof(ISuccessQueryHandler<TQuery, TReturn>));
        }
        protected IEnumerable<IFailQueryHandler<TQuery, TReturn>> GetFailQueryHandlers<TQuery, TReturn>()
            where TQuery : IQuery
        {
            return (IEnumerable<IFailQueryHandler<TQuery, TReturn>>)
                ServiceProvider.GetServices(typeof(IFailQueryHandler<TQuery, TReturn>));
        }
        protected IEnumerable<IQueryHandler<TQuery, TReturn>> GetQueryHandlers<TQuery, TReturn>()
            where TQuery : IQuery
        {
            return (IEnumerable<IQueryHandler<TQuery, TReturn>>)
                ServiceProvider.GetServices(typeof(IQueryHandler<TQuery, TReturn>));
        }

        protected IEnumerable<IEventHandler<TEvent>> GetNotificationEventHandlers<TEvent>()
            where TEvent : EventBase
        {
            return (IEnumerable<IEventHandler<TEvent>>)
                ServiceProvider.GetServices(typeof(IEventHandler<TEvent>));
        }
        protected IEnumerable<IDomainNotificationHandler> GetDomainNotificationHandlers()
        {
            var domainNotifications = (IEnumerable<IDomainNotificationHandler>)
                ServiceProvider.GetServices(typeof(IDomainNotificationHandler));

            var returnList = domainNotifications;

            return returnList;
        }

        protected IEnumerable<IStartWithEventHandler<TEvent>> GetStartWithEventHandlers<TEvent>()
            where TEvent : EventBase
        {
            return (IEnumerable<IStartWithEventHandler<TEvent>>)
                ServiceProvider.GetServices(typeof(IStartWithEventHandler<TEvent>));
        }
        protected IEnumerable<IEndWithEventHandler<TEvent>> GetEndWithEventHandlers<TEvent>()
            where TEvent : EventBase
        {
            return (IEnumerable<IEndWithEventHandler<TEvent>>)
                ServiceProvider.GetServices(typeof(IEndWithEventHandler<TEvent>));
        }
        protected IEnumerable<ISuccessEventHandler<TEvent>> GetSuccessEventHandlers<TEvent>()
            where TEvent : EventBase
        {
            return (IEnumerable<ISuccessEventHandler<TEvent>>)
                ServiceProvider.GetServices(typeof(ISuccessEventHandler<TEvent>));
        }
        protected IEnumerable<IFailEventHandler<TEvent>> GetFailEventHandlers<TEvent>()
            where TEvent : EventBase
        {
            return (IEnumerable<IFailEventHandler<TEvent>>)
                ServiceProvider.GetServices(typeof(IFailEventHandler<TEvent>));
        }
        protected IEnumerable<IEventHandler<TEvent>> GetEventHandlers<TEvent>()
            where TEvent : EventBase
        {
            return (IEnumerable<IEventHandler<TEvent>>)
                ServiceProvider.GetServices(typeof(IEventHandler<TEvent>));
        }

        public abstract Task<EventReturn> SendEvent<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
            where TEvent : EventBase;
        public abstract Task<QueryReturn<TReturn>> GetQuery<TQuery, TReturn>(TQuery query, CancellationToken cancellationToken = default)
            where TQuery : IQuery;
        public abstract Task<CommandReturn<TReturn>> SendCommand<TCommand, TReturn>(TCommand command, CancellationToken cancellationToken = default)
            where TCommand : CommandBase;
        public abstract Task<EventReturn> SendDomainNotification(DomainNotification domainNotification, CancellationToken cancellationToken = default);


    }
}
