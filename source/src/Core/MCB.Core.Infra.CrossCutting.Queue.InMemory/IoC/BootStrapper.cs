using MCB.Core.Infra.CrossCutting.Queue.InMemory.Interfaces;
using MCB.Core.Infra.CrossCutting.Queue.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MCB.Core.Infra.CrossCutting.Queue.InMemory.IoC
{
    public static class BootStrapper
    {
        public static void RegisterServices(
            IServiceCollection services,
            string clienteIdentifier = null)
        {
            services.AddSingleton<InMemoryQueueManager>();
            services.AddScoped<IQueueConnection, InMemoryQueueConnection>();
            services.AddScoped<IQueue, InMemoryQueue>();
            services.AddTransient<IQueueConsumer, InMemoryQueueConsumer>();
            services.AddScoped<IQueuePublisher, InMemoryQueuePublisher>();
            services.AddSingleton<IQueueConsumerPool, InMemoryQueueConsumerPool>();

            services.AddScoped<IInMemoryQueue, InMemoryQueue>();
            services.AddScoped<IInMemoryQueueConnection, InMemoryQueueConnection>();
            services.AddTransient<IInMemoryQueueConsumer, InMemoryQueueConsumer>();
            services.AddScoped<IInMemoryQueueConsumerPool, InMemoryQueueConsumerPool>();
            services.AddScoped<IInMemoryQueuePublisher, InMemoryQueuePublisher>();

        }
    }
}


