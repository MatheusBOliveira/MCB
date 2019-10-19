using MCB.Core.Infra.CrossCutting.Configuration;
using MCB.Core.Infra.CrossCutting.Configuration.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MCB.Core.Infra.Data.Mongo.Tests.IoC
{
    public static class Bootstrapper
    {
        public static void RegisterServices(IServiceCollection service, string clienteIdentifier)
        {
            service.AddScoped<IConfigurationManager>(q =>
            {
                var config = new ConfigurationManager();
                config.LoadConfigurations();

                return config;
            });
        }
    }
}


