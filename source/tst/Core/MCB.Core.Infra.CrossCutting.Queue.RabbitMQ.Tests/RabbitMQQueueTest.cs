using MCB.Core.Infra.CrossCutting.Queue.Delegates;
using MCB.Core.Infra.CrossCutting.Queue.Interfaces;
using MCB.Core.Infra.CrossCutting.Tests;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace MCB.Core.Infra.CrossCutting.Queue.RabbitMQ.Tests
{
    public class RabbitMQQueueTest
        : TestBase<RabbitMQQueueTest>
    {
        public RabbitMQQueueTest(ITestOutputHelper output) 
            : base(output)
        {

        }

        protected override void ConfigureServices(IServiceCollection services)
        {
            IoC.DefaultBootstrapper.RegisterServices(services);
        }
        protected override void ServiceProviderGenerated(IServiceProvider serviceProvider)
        {

        }

        private IQueueConsumer CreateNewConsumerForStressTest(
            string identifier,
            ProcessReceivedMessageHandle handle)
        {
            var newConsumer = ServiceProvider.GetService<IQueueConsumer>();
            newConsumer.Identifier = identifier;
            newConsumer.SetHandle(handle);

            return newConsumer;
        }

        [Fact]
        [Trait("RabbitMQQueue", "PublishMessageTest")]
        public void PublishMessageTest()
        {
            var messages = new Dictionary<string, bool>();
            for (int i = 0; i < 10; i++)
            {
                messages.Add(Guid.NewGuid().ToString(), false);
            }

            var testPublisher = ServiceProvider.GetService<IQueuePublisher>();

            var testConsumer = ServiceProvider.GetService<IQueueConsumer>();
            testConsumer.Identifier = "Consumer 1";
            testConsumer.Start(async (queue, consumer, message) => {

                Output.WriteLine($"{DateTime.Now} - {consumer.Identifier} - Received Message - {message}");

                messages[message] = true;

                Thread.Sleep(250);

                return await Task.FromResult((true, false));
            });

            var testConsumer2 = ServiceProvider.GetService<IQueueConsumer>();
            testConsumer2.Identifier = "Consumer 2";
            testConsumer2.Start(async (queue, consumer, message) => {

                Output.WriteLine($"{DateTime.Now} - {consumer.Identifier} - Received Message - {message}");

                messages[message] = true;

                Thread.Sleep(250);

                return await Task.FromResult((true, false));

            });

            foreach (var message in messages.ToList())
                testPublisher.PublishMessage(message.Key);

            while(!messages.ToList().All(q => q.Value))
            {
                Output.WriteLine($"{DateTime.Now} - Waiting first step");
                Thread.Sleep(500);
            }

            testConsumer.Stop();
            testConsumer2.Stop();

            var messagesKeys = messages.ToList().Select(q => q.Key).ToList();
            foreach (var key in messagesKeys)
                messages[key] = false;

            foreach (var message in messages.ToList())
                testPublisher.PublishMessage(message.Key);

            testConsumer.Start();
            testConsumer2.Start();

            while (!messages.ToList().All(q => q.Value))
            {
                Output.WriteLine($"{DateTime.Now} - Waiting second step");
                Thread.Sleep(500);
            }

            Output.WriteLine($"{DateTime.Now} - Finished");

            Assert.True(true);
        }

        [Fact]
        [Trait("RabbitMQQueue", "PublishMessageWithConsumerPoolTest")]
        public void PublishMessageWithConsumerPoolTest()
        {
            var messages = new Dictionary<string, bool>();
            for (int i = 0; i < 10; i++)
            {
                messages.Add(Guid.NewGuid().ToString(), false);
            }

            var consumerPool = ServiceProvider.GetService<IQueueConsumerPool>();
            var testPublisher = ServiceProvider.GetService<IQueuePublisher>();

            var testConsumer = ServiceProvider.GetService<IQueueConsumer>();
            testConsumer.Identifier = "Consumer 1";
            testConsumer.SetHandle(async (queue, consumer, message) => {

                Output.WriteLine($"{DateTime.Now} - {consumer.Identifier} - Received Message - {message}");

                messages[message] = true;
                 
                Thread.Sleep(250);

                return await Task.FromResult((true, false));
            });

            var testConsumer2 = ServiceProvider.GetService<IQueueConsumer>();
            testConsumer2.Identifier = "Consumer 2";
            testConsumer2.SetHandle(async (queue, consumer, message) => {

                Output.WriteLine($"{DateTime.Now} - {consumer.Identifier} - Received Message - {message}");

                messages[message] = true;

                Thread.Sleep(250);

                return await Task.FromResult((true, false));

            });

            consumerPool.AddConsumer(testConsumer);
            consumerPool.AddConsumer(testConsumer2);

            consumerPool.StartConsumer("Consumer 1");
            consumerPool.StartConsumer("Consumer 2");

            foreach (var message in messages.ToList())
                testPublisher.PublishMessage(message.Key);

            while (!messages.All(q => q.Value))
            {
                Output.WriteLine($"{DateTime.Now} - Waiting first step");
                Thread.Sleep(500);
            }

            consumerPool.StopConsumer("Consumer 1");
            consumerPool.StopConsumer("Consumer 2");

            var messagesKeys = messages.ToList().Select(q => q.Key).ToList();
            foreach (var key in messagesKeys)
                messages[key] = false;

            foreach (var message in messages.ToList())
                testPublisher.PublishMessage(message.Key);

            consumerPool.StartConsumer("Consumer 1");
            consumerPool.StartConsumer("Consumer 2");

            while (!messages.ToList().All(q => q.Value))
            {
                Output.WriteLine($"{DateTime.Now} - Waiting second step");
                Thread.Sleep(500);
            }

            Output.WriteLine($"{DateTime.Now} - Finished");

            Assert.True(
                consumerPool.GetAllConsumers().Count() == 2
                && consumerPool.GetConsumer("Consumer 1") != null
                && consumerPool.GetConsumer("Consumer 2") != null
                && consumerPool.GetAllConsumersIdentifiers().Contains("Consumer 1")
                && consumerPool.GetAllConsumersIdentifiers().Contains("Consumer 2")
                );
        }

        [Fact]
        [Trait("RabbitMQQueue", "PublishMessageWithConsumerPoolStressTest")]
        public void PublishMessageWithConsumerPoolStressTest()
        {
            var totalOfConsumers = 50;
            var totalOfMessages = 100;
            var messages = new string[totalOfMessages];
            var received = new bool[totalOfMessages];

            for (int i = 0; i < totalOfMessages; i++)
                messages[i] = i.ToString();

            var consumerPool = ServiceProvider.GetService<IQueueConsumerPool>();
            var testPublisher = ServiceProvider.GetService<IQueuePublisher>();

            for (int i = 0; i < totalOfConsumers; i++)
                consumerPool.AddConsumer(CreateNewConsumerForStressTest(
                    i.ToString(),
                    async (queue, consumer, message) =>
                    {
                        received[int.Parse(message)] = true;

                        return await Task.FromResult((true, false));
                    }));

            for (int i = 0; i < totalOfConsumers; i++)
                consumerPool.StartConsumer(i.ToString());

            for (int i = 0; i < totalOfMessages; i++)
                testPublisher.PublishMessage(messages[i]);

            while (received.Any(q => !q))
                Thread.Sleep(500);

            for (int i = 0; i < totalOfConsumers; i++)
                consumerPool.StopConsumer(i.ToString());

            for (int i = 0; i < totalOfMessages; i++)
                received[i] = false;

            for (int i = 0; i < totalOfMessages; i++)
                testPublisher.PublishMessage(messages[i]);

            for (int i = 0; i < totalOfConsumers; i++)
                consumerPool.StartConsumer(i.ToString());

            while (received.Any(q => !q))
                Thread.Sleep(500);

            Output.WriteLine($"{DateTime.Now} - Finished");

            consumerPool.DisposeAllConsumers();
            consumerPool.RemoveAllConsumers();

            testPublisher.Dispose();

            Assert.True(true);
        }
    }
}


