using MCB.Core.Infra.CrossCutting.Security.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MCB.Core.Infra.CrossCutting.Security.IoC
{
    public static class DefaultBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ICryptography>(q => new Cryptography("3946E0ED-A8D6-4B50-954F-53CE0E6077D1"));
        }
    }
}


