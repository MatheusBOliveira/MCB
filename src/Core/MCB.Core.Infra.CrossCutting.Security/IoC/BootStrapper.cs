using Microsoft.Extensions.DependencyInjection;

namespace MCB.Core.Infra.CrossCutting.Security.IoC
{
    public static class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services, string clienteIdentifier)
        {
            services.AddScoped(q => new Cryptography("3946E0ED-A8D6-4B50-954F-53CE0E6077D1"));
        }
    }
}


