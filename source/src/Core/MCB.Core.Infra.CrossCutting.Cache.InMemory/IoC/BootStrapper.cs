using MCB.Core.Infra.CrossCutting.Cache.InMemory.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MCB.Core.Infra.CrossCutting.Cache.InMemory.IoC
{
    public static class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services, string clienteIdentifier)
        {
            services.AddScoped<IInMemoryCache, InMemoryCache>();
        }
    }
}


