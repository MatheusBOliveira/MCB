using MCB.Core.Infra.CrossCutting.Bus.InMemory.Tests.Commands;
using MCB.Core.Infra.CrossCutting.Bus.InMemory.Tests.Events;
using MCB.Core.Infra.CrossCutting.Bus.InMemory.Tests.Handlers.CommandHandlers;
using MCB.Core.Infra.CrossCutting.Bus.Interfaces.CommandHandlers;
using MCB.Core.Infra.CrossCutting.Tests;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Xunit;
using System.Collections.Generic;
using MCB.Core.Infra.CrossCutting.Bus.InMemory.Tests.Handlers.EventHandlers;
using MCB.Core.Infra.CrossCutting.Bus.Interfaces.EventHandlers;
using MCB.Core.Infra.CrossCutting.Bus.Interfaces.QueryHandlers;
using MCB.Core.Infra.CrossCutting.Bus.InMemory.Tests.Queries;
using MCB.Core.Infra.CrossCutting.Bus.InMemory.Tests.Handlers.QueryHandlers;
using MCB.Core.Infra.CrossCutting.Bus.InMemory.Tests.Models;
using MCB.Core.Infra.CrossCutting.Bus.InMemory.Tests.Handlers.DomainNotificationHandler;
using Xunit.Abstractions;

namespace MCB.Core.Infra.CrossCutting.Bus.InMemory.Tests
{
    public class InMemoryBusTest
        : TestBase<InMemoryBusTest>
    {
        private readonly InMemoryBus _inMemoryBus;

        public static List<string> EventSuccessMessageList;
        public static List<string> EventFailMessageList;

        static InMemoryBusTest()
        {
            EventSuccessMessageList = new List<string>();
            EventFailMessageList = new List<string>();
        }

        public InMemoryBusTest(ITestOutputHelper output) 
            : base(output)
        {
            _inMemoryBus = new InMemoryBus(ServiceProvider);
        }

        protected override void ConfigureServices(IServiceCollection service)
        {
            service.AddScoped<IStartWithCommandHandler<SuccessCommand, SuccessEvent>, SuccessCommandHandler>();
            service.AddScoped<ICommandHandler<SuccessCommand, SuccessEvent>, SuccessCommandHandler>();
            service.AddScoped<IEndWithCommandHandler<SuccessCommand, SuccessEvent>, SuccessCommandHandler>();
            service.AddScoped<ISuccessCommandHandler<SuccessCommand, SuccessEvent>, SuccessCommandHandler>();

            service.AddScoped<IStartWithCommandHandler<FailCommand, SuccessEvent>, FailCommandHandler>();
            service.AddScoped<ICommandHandler<FailCommand, SuccessEvent>, FailCommandHandler>();
            service.AddScoped<IEndWithCommandHandler<FailCommand, SuccessEvent>, FailCommandHandler>();
            service.AddScoped<IFailCommandHandler<FailCommand, SuccessEvent>, FailCommandHandler>();

            service.AddScoped<IStartWithEventHandler<SuccessEvent>, SuccessEventHandler>();
            service.AddScoped<IEventHandler<SuccessEvent>, SuccessEventHandler>();
            service.AddScoped<IEndWithEventHandler<SuccessEvent>, SuccessEventHandler>();
            service.AddScoped<ISuccessEventHandler<SuccessEvent>, SuccessEventHandler>();

            service.AddScoped<IStartWithEventHandler<FailEvent>, FailEventHandler>();
            service.AddScoped<IEventHandler<FailEvent>, FailEventHandler>();
            service.AddScoped<IEndWithEventHandler<FailEvent>, FailEventHandler>();
            service.AddScoped<IFailEventHandler<FailEvent>, FailEventHandler>();

            service.AddScoped<IStartWithQueryHandler<SuccessQuery, Customer>, SuccessQueryHandler>();
            service.AddScoped<IQueryHandler<SuccessQuery, Customer>, SuccessQueryHandler>();
            service.AddScoped<IEndWithQueryHandler<SuccessQuery, Customer>, SuccessQueryHandler>();
            service.AddScoped<ISuccessQueryHandler<SuccessQuery, Customer>, SuccessQueryHandler>();

            service.AddScoped<IStartWithQueryHandler<FailQuery, Customer>, FailQueryHandler>();
            service.AddScoped<IQueryHandler<FailQuery, Customer>, FailQueryHandler>();
            service.AddScoped<IEndWithQueryHandler<FailQuery, Customer>, FailQueryHandler>();
            service.AddScoped<IFailQueryHandler<FailQuery, Customer>, FailQueryHandler>();

            service.AddScoped<IDomainNotificationHandler, DomainNotificationHandler>();
        }

        [Fact]
        [Trait("InMemoryBus", "CommandHandlerSuccessTest")]
        public async void CommandHandlerSuccessTest()
        {
            var successCommand = 
                new SuccessCommand("Marcelo Castelo Branco", "marcelo.castelo@outlook.com");

            var commandReturn = await _inMemoryBus
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
        [Trait("InMemoryBus", "CommandHandlerFailsTest")]
        public async void CommandHandlerFailsTest()
        {
            var failCommand =
                new FailCommand("Marcelo Castelo Branco", "marcelo.castelo@outlook.com");

            var commandReturn = await _inMemoryBus
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
        [Trait("InMemoryBus", "EventHandlerSuccessTest")]
        public async void EventHandlerSuccessTest()
        {
            var successEvent = new SuccessEvent();

            var eventReturn = await _inMemoryBus.SendEvent(
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
        [Trait("InMemoryBus", "EventHandlerFailTest")]
        public async void EventHandlerFailTest()
        {
            var failEvent = new FailEvent();

            var eventReturn = await _inMemoryBus.SendEvent(
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
        [Trait("InMemoryBus", "QueryHandlerSuccessTest")]
        public async void QueryHandlerSuccessTest()
        {
            var name = "Marcelo Castelo Branco";
            var email = "marcelo.castelo@outlook.com";

            var successQuery =
                new SuccessQuery(email);

            var queryReturn = await _inMemoryBus
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
        [Trait("InMemoryBus", "QueryHandlerFailTest")]
        public async void QueryHandlerFailTest()
        {
            var name = "Marcelo Castelo Branco";
            var email = "marcelo.castelo@outlook.com";

            var failQuery =
                new FailQuery(email);

            var queryReturn = await _inMemoryBus
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
        [Trait("InMemoryBus", "DomainNotificationTest")]
        public async void DomainNotificationTest()
        {
            var domainNotificationHandler = ServiceProvider
                .GetService<IDomainNotificationHandler>();

            await _inMemoryBus.SendDomainNotification(
                new Patterns.CQRS.Notifications.DomainNotification("key1", "value1"),
                new System.Threading.CancellationToken());

            await _inMemoryBus.SendDomainNotification(
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


