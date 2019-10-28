using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Saga;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Saga.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MCB.Core.Infra.CrossCutting.Patterns.IoC
{
    public static class DefaultBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ISagaManager, InMemorySagaManager>();
        }
    }
}


