using MCB.Core.Infra.CrossCutting.Globalization.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MCB.Core.Infra.CrossCutting.Globalization.IoC
{
    public static class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services, string clienteIdentifier)
        {
            services.AddSingleton<IGlobalizationManager>(q =>
            {
                var globalizationManager = new GlobalizationManager();
                globalizationManager.LoadGlobalizationMessages();

                return globalizationManager;
            });
        }
    }
}


