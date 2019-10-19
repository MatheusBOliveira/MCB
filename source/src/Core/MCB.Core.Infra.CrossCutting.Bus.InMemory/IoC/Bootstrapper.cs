using MCB.Core.Infra.CrossCutting.Bus.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MCB.Core.Infra.CrossCutting.Bus.InMemory.IoC
{
    public static class Bootstrapper
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IBus, InMemoryBus>();
        }
    }
}


