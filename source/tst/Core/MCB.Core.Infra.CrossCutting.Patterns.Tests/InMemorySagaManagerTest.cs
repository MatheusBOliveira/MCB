using MCB.Core.Infra.CrossCutting.Patterns.Tests.Commands;
using MCB.Core.Infra.CrossCutting.Patterns.Tests.Events;
using MCB.Core.Infra.CrossCutting.Patterns.Tests.Handlers.CommandHandlers;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.CommandHandlers.Interfaces;
using MCB.Core.Infra.CrossCutting.Tests;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Xunit;
using System.Collections.Generic;
using MCB.Core.Infra.CrossCutting.Patterns.Tests.Handlers.EventHandlers;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.EventHandlers.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.QueryHandlers.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.Tests.Queries;
using MCB.Core.Infra.CrossCutting.Patterns.Tests.Handlers.QueryHandlers;
using MCB.Core.Infra.CrossCutting.Patterns.Tests.Models;
using Xunit.Abstractions;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Saga;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.EventHandlers;

namespace MCB.Core.Infra.CrossCutting.Patterns.Tests
{
    public class InMemorySagaManagerTest
        : TestBase<InMemorySagaManagerTest>
    {
        private readonly InMemorySagaManager _inMemorySagaManager;

        public static List<string> EventSuccessMessageList;
        public static List<string> EventFailMessageList;

        static InMemorySagaManagerTest()
        {
            EventSuccessMessageList = new List<string>();
            EventFailMessageList = new List<string>();
        }

        public InMemorySagaManagerTest(ITestOutputHelper output) 
            : base(output)
        {
            _inMemorySagaManager = new InMemorySagaManager(ServiceProvider);
        }
        protected override void ServiceProviderGenerated(IServiceProvider serviceProvider)
        {

        }

        protected override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IStartWithCommandHandler<SuccessCommand, SuccessEvent>, SuccessCommandHandler>();
            services.AddScoped<ICommandHandler<SuccessCommand, SuccessEvent>, SuccessCommandHandler>();
            services.AddScoped<IEndWithCommandHandler<SuccessCommand, SuccessEvent>, SuccessCommandHandler>();
            services.AddScoped<ISuccessCommandHandler<SuccessCommand, SuccessEvent>, SuccessCommandHandler>();

            services.AddScoped<IStartWithCommandHandler<FailCommand, SuccessEvent>, FailCommandHandler>();
            services.AddScoped<ICommandHandler<FailCommand, SuccessEvent>, FailCommandHandler>();
            services.AddScoped<IEndWithCommandHandler<FailCommand, SuccessEvent>, FailCommandHandler>();
            services.AddScoped<IFailCommandHandler<FailCommand, SuccessEvent>, FailCommandHandler>();

            services.AddScoped<IStartWithEventHandler<SuccessEvent>, SuccessEventHandler>();
            services.AddScoped<IEventHandler<SuccessEvent>, SuccessEventHandler>();
            services.AddScoped<IEndWithEventHandler<SuccessEvent>, SuccessEventHandler>();
            services.AddScoped<ISuccessEventHandler<SuccessEvent>, SuccessEventHandler>();

            services.AddScoped<IStartWithEventHandler<FailEvent>, FailEventHandler>();
            services.AddScoped<IEventHandler<FailEvent>, FailEventHandler>();
            services.AddScoped<IEndWithEventHandler<FailEvent>, FailEventHandler>();
            services.AddScoped<IFailEventHandler<FailEvent>, FailEventHandler>();

            services.AddScoped<IStartWithQueryHandler<SuccessQuery, Customer>, SuccessQueryHandler>();
            services.AddScoped<IQueryHandler<SuccessQuery, Customer>, SuccessQueryHandler>();
            services.AddScoped<IEndWithQueryHandler<SuccessQuery, Customer>, SuccessQueryHandler>();
            services.AddScoped<ISuccessQueryHandler<SuccessQuery, Customer>, SuccessQueryHandler>();

            services.AddScoped<IStartWithQueryHandler<FailQuery, Customer>, FailQueryHandler>();
            services.AddScoped<IQueryHandler<FailQuery, Customer>, FailQueryHandler>();
            services.AddScoped<IEndWithQueryHandler<FailQuery, Customer>, FailQueryHandler>();
            services.AddScoped<IFailQueryHandler<FailQuery, Customer>, FailQueryHandler>();

            services.AddScoped<IDomainNotificationHandler, DomainNotificationHandler>();
        }

        [Fact]
        [Trait("InMemorySagaManager", "CommandHandlerSuccessTest")]
        public async void CommandHandlerSuccessTest()
        {
            var successCommand = 
                new SuccessCommand("Marcelo Castelo Branco", "marcelo.castelo@outlook.com");

            var commandReturn = await _inMemorySagaManager
                .SendCommand<SuccessCommand, SuccessEvent>(
                    successCommand,
                    new System.Threading.CancellationToken());

            if (
                commandReturn == null
                || !commandReturn.Success
                || !commandReturn.Continue
                || commandReturn.ReturnObject == null
                || commandReturn.ReturnObject.Id == Guid.Empty
                || !commandReturn.ReturnObject.Name.Equals(successCommand.Name)
                || !commandReturn.ReturnObject.EmailAddress.Equals(successCommand.EmailAddress)
                || !commandReturn.ReturnObject.Roles.Any(q => q.Equals("admin"))
                )
                Assert.True(false);
            
            Assert.True(true);
        }
        [Fact]
        [Trait("InMemorySagaManager", "CommandHandlerFailsTest")]
        public async void CommandHandlerFailsTest()
        {
            var failCommand =
                new FailCommand("Marcelo Castelo Branco", "marcelo.castelo@outlook.com");

            var commandReturn = await _inMemorySagaManager
                .SendCommand<FailCommand, SuccessEvent>(
                    failCommand,
                    new System.Threading.CancellationToken());

            if (
                commandReturn == null
                || commandReturn.Success
                || commandReturn.Continue
                || commandReturn.ReturnObject == null
                || commandReturn.ReturnObject.Id == Guid.Empty
                || !commandReturn.ReturnObject.Name.Equals(failCommand.Name)
                || commandReturn.ReturnObject.EmailAddress.Equals(failCommand.EmailAddress)
                || commandReturn.ReturnObject.Roles.Any()
                )
                Assert.True(false);

            Assert.True(true);
        }

        [Fact]
        [Trait("InMemorySagaManager", "EventHandlerSuccessTest")]
        public async void EventHandlerSuccessTest()
        {
            var successEvent = new SuccessEvent();

            var eventReturn = await _inMemorySagaManager.SendEvent(
                successEvent,
                new System.Threading.CancellationToken());

            if (eventReturn == null
                || !eventReturn.Continue
                || !eventReturn.Success
                || !EventSuccessMessageList.Contains("HandleStartWith")
                || !EventSuccessMessageList.Contains("Handle")
                || !EventSuccessMessageList.Contains("HandleEndWith")
                || !EventSuccessMessageList.Contains("HandleSuccess")
                )
                Assert.True(false);

            Assert.True(true);
        }
        [Fact]
        [Trait("InMemorySagaManager", "EventHandlerFailTest")]
        public async void EventHandlerFailTest()
        {
            var failEvent = new FailEvent();

            var eventReturn = await _inMemorySagaManager.SendEvent(
                failEvent,
                new System.Threading.CancellationToken());

            if (eventReturn == null
                || eventReturn.Continue
                || eventReturn.Success
                || !EventFailMessageList.Contains("HandleStartWith")
                || !EventFailMessageList.Contains("Handle")
                || EventFailMessageList.Contains("HandleEndWith")
                || !EventFailMessageList.Contains("HandleFailWith")
                )
                Assert.True(false);

            Assert.True(true);
        }

        [Fact]
        [Trait("InMemorySagaManager", "QueryHandlerSuccessTest")]
        public async void QueryHandlerSuccessTest()
        {
            var name = "Marcelo Castelo Branco";
            var email = "marcelo.castelo@outlook.com";

            var successQuery =
                new SuccessQuery(email);

            var queryReturn = await _inMemorySagaManager
                .GetQuery<SuccessQuery, Customer>(
                    successQuery,
                    new System.Threading.CancellationToken());

            if (
                queryReturn == null
                || !queryReturn.Success
                || !queryReturn.Continue
                || queryReturn.ReturnObject == null
                || queryReturn.ReturnObject.Id == Guid.Empty
                || !queryReturn.ReturnObject.Name.Equals(name)
                || !queryReturn.ReturnObject.EmailAddress.Equals(email)
                || !queryReturn.ReturnObject.Roles.Any(q => q.Equals("admin"))
                )
                Assert.True(false);

            Assert.True(true);
        }

        [Fact]
        [Trait("InMemorySagaManager", "QueryHandlerFailTest")]
        public async void QueryHandlerFailTest()
        {
            var name = "Marcelo Castelo Branco";
            var email = "marcelo.castelo@outlook.com";

            var failQuery =
                new FailQuery(email);

            var queryReturn = await _inMemorySagaManager
                .GetQuery<FailQuery, Customer>(
                    failQuery,
                    new System.Threading.CancellationToken());

            if (
                queryReturn == null
                || queryReturn.Success
                || queryReturn.Continue
                || queryReturn.ReturnObject == null
                || queryReturn.ReturnObject.Id == Guid.Empty
                || !queryReturn.ReturnObject.Name.Equals(name)
                || !queryReturn.ReturnObject.EmailAddress.Equals(email)
                || queryReturn.ReturnObject.Roles.Any(q => q.Equals("admin"))
                )
                Assert.True(false);

            Assert.True(true);
        }

        [Fact]
        [Trait("InMemorySagaManager", "DomainNotificationTest")]
        public async void DomainNotificationTest()
        {
            var domainNotificationHandler = ServiceProvider
                .GetService<IDomainNotificationHandler>();

            await _inMemorySagaManager.SendDomainNotification(
                new Patterns.CQRS.Notifications.DomainNotification("key1", "value1"),
                new System.Threading.CancellationToken());

            await _inMemorySagaManager.SendDomainNotification(
                new Patterns.CQRS.Notifications.DomainNotification("key2", "value2"),
                new System.Threading.CancellationToken());

            var messages = domainNotificationHandler.GetNotifications();

            if (!domainNotificationHandler.HasNotifications()
                || messages.Count() != 2
                || !messages.Any(q => q.Code.Equals("key1"))
                || !messages.Any(q => q.Code.Equals("key2"))
                )
            {
                Assert.True(false);
            }

            Assert.True(true);
        }
    }
}


