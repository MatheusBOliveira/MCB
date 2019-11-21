using MCB.Core.Infra.CrossCutting.Security.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using MCB.Core.Infra.CrossCutting.ExtensionMethods;

namespace MCB.Core.Infra.CrossCutting.Security.IoC
{
    public static class DefaultBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            var key = "3946E0EDA8D64B50954F53CE0E6077D1".GetByteArray();
            var subKey = "AD31DE9A93FC4B6D".GetByteArray();

            services.AddScoped<ICryptography>(q => new Cryptography(key, subKey));
        }
    }
}


