using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Notifications;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Queries;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Saga.Base;
using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Patterns.CQRS.Saga
{
    public class InMemorySagaManager
        : SagaManagerBase
    {
        public InMemorySagaManager(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {

        }

        public override async Task<QueryReturn<TReturn>> GetQuery<TQuery, TReturn>(TQuery query, CultureInfo culture, CancellationToken cancellationToken = default)
        {
            var hasHandle = false;

            #region Get Handlers
            var startWithHandler = GetStartWithQueryHandlers<TQuery, TReturn>()
                    .FirstOrDefault();

            var endWithHandler = GetEndWithQueryHandlers<TQuery, TReturn>()
                .FirstOrDefault();

            var handlers = GetQueryHandlers<TQuery, TReturn>();

            var failHandler = GetFailQueryHandlers<TQuery, TReturn>()
                .FirstOrDefault();

            var successHandler = GetSuccessQueryHandlers<TQuery, TReturn>()
                .FirstOrDefault();
            #endregion

            var queryReturn = new QueryReturn<TReturn>(false, false);

            #region StartWith
            if (startWithHandler != null)
            {
                hasHandle = true;

                queryReturn = await startWithHandler?.HandleStartWith(query, default, culture, cancellationToken);
                if (queryReturn != null)
                {
                    if (queryReturn.Success == false)
                        queryReturn = await failHandler?.HandleFail(query, queryReturn.ReturnObject, culture, cancellationToken);

                    if (!queryReturn.Continue)
                        return await Task.FromResult(queryReturn);
                }
            }
            #endregion

            #region Handler
            if (handlers != null)
            {
                hasHandle = true;

                foreach (var handle in handlers)
                {
                    queryReturn = await handle.Handle(query, queryReturn.ReturnObject, culture, cancellationToken);
                    if (queryReturn != null)
                    {
                        if (queryReturn.Success == false)
                            queryReturn = await failHandler?.HandleFail(query, queryReturn.ReturnObject, culture, cancellationToken);

                        if (!queryReturn.Continue)
                            return await Task.FromResult(queryReturn);
                    }
                }
            }
            #endregion

            #region EndWith
            if (endWithHandler != null)
            {
                hasHandle = true;

                queryReturn = await endWithHandler.HandleEndWith(query, queryReturn.ReturnObject, culture, cancellationToken);
                if (queryReturn != null)
                {
                    if (queryReturn.Success == false)
                        queryReturn = await failHandler?.HandleFail(query, queryReturn.ReturnObject, culture, cancellationToken);

                    if (!queryReturn.Continue)
                        return await Task.FromResult(queryReturn);
                }
            }
            #endregion

            #region Success
            if (successHandler != null)
            {
                hasHandle = true;

                queryReturn = await successHandler?.HandleSuccess(query, queryReturn.ReturnObject, culture, cancellationToken);
                if (queryReturn != null)
                    return await Task.FromResult(queryReturn);
            }
            #endregion

            queryReturn.Success = hasHandle;
            queryReturn.Continue = hasHandle;

            return await Task.FromResult(queryReturn);
        }
        public override async Task<CommandReturn<TReturn>> SendCommand<TCommand, TReturn>(TCommand command, CultureInfo culture, CancellationToken cancellationToken = default)
        {
            var hasHandle = false;

            #region Get Handlers
            var startWithHandler = GetStartWithCommandHandlers<TCommand, TReturn>()
                    .FirstOrDefault();

            var endWithHandler = GetEndWithCommandHandlers<TCommand, TReturn>()
                .FirstOrDefault();

            var handlers = GetCommandHandlers<TCommand, TReturn>();

            var failHandler = GetFailCommandHandlers<TCommand, TReturn>()
                .FirstOrDefault();

            var successHandler = GetSuccessCommandHandlers<TCommand, TReturn>()
                .FirstOrDefault();
            #endregion

            var commandReturn = new CommandReturn<TReturn>(false, false);

            #region StartWith
            if (startWithHandler != null)
            {
                hasHandle = true;

                commandReturn = await startWithHandler?.HandleStartWith(command, commandReturn.ReturnObject, culture, cancellationToken);
                if (commandReturn != null)
                {
                    if (commandReturn.Success == false)
                        commandReturn = await failHandler?.HandleFailWith(command, commandReturn.ReturnObject, culture, cancellationToken);

                    if (!commandReturn.Continue)
                        return await Task.FromResult(commandReturn);
                }
            }
            #endregion

            #region Handlers
            if (handlers != null
                && handlers.Any())
            {
                hasHandle = true;

                foreach (var handle in handlers)
                {
                    commandReturn = await handle.Handle(command, commandReturn.ReturnObject, culture, cancellationToken);
                    if (commandReturn != null)
                    {
                        if (commandReturn.Success == false
                            && failHandler != null)
                            commandReturn = await failHandler?.HandleFailWith(command, commandReturn.ReturnObject, culture, cancellationToken);

                        if (!commandReturn.Continue)
                            return await Task.FromResult(commandReturn);
                    }
                }
            }
            #endregion

            #region EndWith
            if (endWithHandler != null)
            {
                hasHandle = true;

                commandReturn = await endWithHandler?.HandleEndWith(command, commandReturn.ReturnObject, culture, cancellationToken);
                if (commandReturn != null)
                {
                    if (commandReturn.Success == false)
                        commandReturn = await failHandler?.HandleFailWith(command, commandReturn.ReturnObject, culture, cancellationToken);

                    if (!commandReturn.Continue)
                        return await Task.FromResult(commandReturn);
                }
            }
            #endregion

            #region Success
            if (successHandler != null)
            {
                hasHandle = true;

                commandReturn = await successHandler?.HandleSuccess(command, commandReturn.ReturnObject, culture, cancellationToken);
                if (commandReturn != null)
                {
                    if (commandReturn.Success == false)
                        commandReturn = await failHandler?.HandleFailWith(command, commandReturn.ReturnObject, culture, cancellationToken);

                    return await Task.FromResult(commandReturn);
                }
            }
            #endregion

            commandReturn.Success = hasHandle;
            commandReturn.Continue = hasHandle;

            return await Task.FromResult(commandReturn);
        }
        public override async Task<EventReturn> SendDomainNotification(DomainNotification domainNotification, CultureInfo culture, CancellationToken cancellationToken = default)
        {
            var hasHandle = false;

            var domainNotificationHandlerCollection = GetDomainNotificationHandlers();
            if (domainNotificationHandlerCollection != null)
            {
                hasHandle = true;

                foreach (var domainNotificationHandler in domainNotificationHandlerCollection)
                {
                    var eventReturn = await domainNotificationHandler.Handle(domainNotification, culture, cancellationToken);
                    
                    if (!eventReturn.Continue)
                        return await Task.FromResult(eventReturn);
                }
            }

            if (!hasHandle)
                return await Task.FromResult(new EventReturn(false, false));

            return await Task.FromResult(new EventReturn(true, true));
        }
        public override async Task<EventReturn> SendEvent<TEvent>(TEvent Event, CultureInfo culture, CancellationToken cancellationToken = default)
        {
            var hasHandle = false;

            #region Get Handlers
            var startWithHandler = GetStartWithEventHandlers<TEvent>()
                    .FirstOrDefault();

            var endWithHandler = GetEndWithEventHandlers<TEvent>()
                .FirstOrDefault();

            var handlers = GetEventHandlers<TEvent>();

            var failHandler = GetFailEventHandlers<TEvent>()
                .FirstOrDefault();

            var successHandler = GetSuccessEventHandlers<TEvent>()
                .FirstOrDefault();
            #endregion

            #region StartWith
            if (startWithHandler != null)
            {
                hasHandle = true;

                var startWithEventReturn = await startWithHandler?.HandleStartWith(Event, culture, cancellationToken);
                if (startWithEventReturn != null)
                {
                    if (startWithEventReturn.Success == false)
                        failHandler?.HandleFailWith(Event, culture, cancellationToken);

                    if (!startWithEventReturn.Continue)
                        return await Task.FromResult(startWithEventReturn);
                }
            }
            #endregion

            #region Handlers
            if (handlers != null)
            {
                hasHandle = true;

                foreach (var handle in handlers)
                {
                    var handleEventReturn = await handle.Handle(Event, culture, cancellationToken);
                    if (handleEventReturn != null)
                    {
                        if (handleEventReturn.Success == false)
                            failHandler?.HandleFailWith(Event, culture, cancellationToken);

                        if (!handleEventReturn.Continue)
                            return await Task.FromResult(handleEventReturn);
                    }
                }
            }
            #endregion

            #region EndWith
            if (endWithHandler != null)
            {
                hasHandle = true;

                var endWithEventReturn = await endWithHandler?.HandleEndWith(Event, culture, cancellationToken);
                if (endWithEventReturn != null)
                {
                    if (endWithEventReturn.Success == false)
                        failHandler?.HandleFailWith(Event, culture, cancellationToken);

                    if (!endWithEventReturn.Continue)
                        return await Task.FromResult(endWithEventReturn);
                }
            }
            #endregion

            #region Success
            if (successHandler != null)
            {
                hasHandle = true;

                var successEventReturn = await successHandler?.HandleSuccess(Event, culture, cancellationToken);
                if (successEventReturn != null)
                {
                    if (successEventReturn.Success == false)
                        failHandler?.HandleFailWith(Event, culture, cancellationToken);

                    return await Task.FromResult(successEventReturn);
                }
            }
            #endregion

            if (!hasHandle)
                return await Task.FromResult(new EventReturn(true, true));

            return await Task.FromResult(new EventReturn(true, true));
        }
    }
}


