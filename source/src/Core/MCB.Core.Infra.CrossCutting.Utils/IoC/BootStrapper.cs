using Microsoft.Extensions.DependencyInjection;

namespace MCB.Core.Infra.CrossCutting.Utils.IoC
{
    public static class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services, string clienteIdentifier)
        {
            services.AddScoped<Utils>();
            services.AddScoped<WebUtils>();
        }
    }
}


