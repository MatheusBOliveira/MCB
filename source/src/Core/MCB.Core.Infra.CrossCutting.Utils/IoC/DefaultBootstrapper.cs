using Microsoft.Extensions.DependencyInjection;

namespace MCB.Core.Infra.CrossCutting.Utils.IoC
{
    public static class DefaultBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<Utils>();
            services.AddScoped<WebUtils>();
        }
    }
}


