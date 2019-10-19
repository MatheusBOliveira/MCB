using MCB.Core.Infra.CrossCutting.Queue.Interfaces;
using MCB.Core.Infra.CrossCutting.Tests;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace MCB.Core.Infra.CrossCutting.Queue.InMemory.Tests
{
    public class InMemoryQueueTest
        : TestBase<InMemoryQueueTest>
    {
        public InMemoryQueueTest(ITestOutputHelper output)
            : base(output)
        {
        }

        protected override void ConfigureServices(IServiceCollection services)
        {
            IoC.BootStrapper.RegisterServices(services);
        }

        [Fact]
        [Trait("InMemoryQueue", "PublishMessageTest")]
        public void PublishMessageTest()
        {
            bool receivedConsumer1 = false;
            bool receivedConsumer2 = false;

            var testPublisher = ServiceProvider.GetService<IQueuePublisher>();

            var testConsumer = ServiceProvider.GetService<IQueueConsumer>();
            testConsumer.Identifier = "Consumer 1";
            testConsumer.Start(async (queue, consumer, message) => {

                Output.WriteLine($"{DateTime.Now} - {consumer.Identifier} - Received Message - {message}");

                receivedConsumer1 = message.Equals("Hi =D 2");

                return await Task.FromResult((true, false));

            });

            var testConsumer2 = ServiceProvider.GetService<IQueueConsumer>();
            testConsumer2.Identifier = "Consumer 2";
            testConsumer2.Start(async (queue, consumer, message) => {

                Output.WriteLine($"{DateTime.Now} - {consumer.Identifier} - Received Message - {message}");

                receivedConsumer2 = message.Equals("Hi =D 2");

                return await Task.FromResult((true, false));

            });

            testPublisher.PublishMessage("Hi =D");
            testPublisher.PublishMessage("Hi =D 2");

            while (!(
                receivedConsumer1
                && receivedConsumer2
                ))
            {
                Output.WriteLine($"{DateTime.Now} - Waiting first step");
                Thread.Sleep(500);
            }

            testConsumer.Stop();
            testConsumer2.Stop();

            receivedConsumer1 = false;
            receivedConsumer2 = false;

            testPublisher.PublishMessage("Hi =D");
            testPublisher.PublishMessage("Hi =D 2");

            testConsumer.Start();
            testConsumer2.Start();

            while (!(
                receivedConsumer1
                && receivedConsumer2
                ))
            {
                Output.WriteLine($"{DateTime.Now} - Waiting second step");
                Thread.Sleep(500);
            }

            Output.WriteLine($"{DateTime.Now} - Finished");

            Assert.True(true);
        }

        [Fact]
        [Trait("InMemoryQueue", "PublishMessageWithConsumerPoolTest")]
        public void PublishMessageWithConsumerPoolTest()
        {
            bool receivedConsumer1 = false;
            bool receivedConsumer2 = false;

            var consumerPool = ServiceProvider.GetService<IQueueConsumerPool>();
            var testPublisher = ServiceProvider.GetService<IQueuePublisher>();

            var testConsumer = ServiceProvider.GetService<IQueueConsumer>();
            testConsumer.Identifier = "Consumer 1";
            testConsumer.SetHandle(async (queue, consumer, message) => {

                Output.WriteLine($"{DateTime.Now} - {consumer.Identifier} - Received Message - {message}");

                receivedConsumer1 = message.Equals("Hi =D 2");

                return await Task.FromResult((true, false));

            });

            var testConsumer2 = ServiceProvider.GetService<IQueueConsumer>();
            testConsumer2.Identifier = "Consumer 2";
            testConsumer2.SetHandle(async (queue, consumer, message) => {

                Output.WriteLine($"{DateTime.Now} - {consumer.Identifier} - Received Message - {message}");

                receivedConsumer2 = message.Equals("Hi =D 2");

                return await Task.FromResult((true, false));

            });

            consumerPool.AddConsumer(testConsumer);
            consumerPool.AddConsumer(testConsumer2);

            consumerPool.StartConsumer("Consumer 1");
            consumerPool.StartConsumer("Consumer 2");

            testPublisher.PublishMessage("Hi =D");
            testPublisher.PublishMessage("Hi =D 2");

            while (!(
                receivedConsumer1
                && receivedConsumer2
                ))
            {
                Output.WriteLine($"{DateTime.Now} - Waiting first step");
                Thread.Sleep(500);
            }

            consumerPool.StopConsumer("Consumer 1");
            consumerPool.StopConsumer("Consumer 2");

            receivedConsumer1 = false;
            receivedConsumer2 = false;

            testPublisher.PublishMessage("Hi =D");
            testPublisher.PublishMessage("Hi =D 2");

            consumerPool.StartConsumer("Consumer 1");
            consumerPool.StartConsumer("Consumer 2");

            while (!(
                receivedConsumer1
                && receivedConsumer2
                ))
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
    }
}


