using MCB.Core.Infra.CrossCutting.Queue.Interfaces;
using MCB.Core.Infra.CrossCutting.Queue.RabbitMQ.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MCB.Core.Infra.CrossCutting.Queue.RabbitMQ.Tests.IoC
{
    public static class Bootstrapper
    {
        public static void RegisterServices(
            IServiceCollection services,
            string clienteIdentifier = null)
        {
            var connection = new RabbitMQConnection
            {
                Hostname = "localhost",
                Port = 6021,
                Username = "guest",
                Password = "guest"
            };
            var queue = new RabbitMQQueue
            {
                Arguments = null,
                AutoAck = false,
                AutoDelete = false,
                Durable = false,
                ExchangeName = null,
                Exclusive = false,
                IsExchange = false,
                Name = "MCB.Core.Infra.CrossCutting.Queue.RabbitMQ.Tests"
            };

            services.AddTransient<IQueueConnection>(q => connection);
            services.AddTransient<IRabbitMQConnection>(q => connection);

            services.AddTransient<IQueue>(q => queue);
            services.AddTransient<IRabbitMQQueue>(q => queue);

            services.AddTransient<IQueueConsumer, RabbitMQConsumer>();
            services.AddTransient<IQueuePublisher, RabbitMQPublisher>();
            services.AddTransient<IQueueConsumerPool, RabbitMQQueueConsumerPool>();
        }
    }
}


