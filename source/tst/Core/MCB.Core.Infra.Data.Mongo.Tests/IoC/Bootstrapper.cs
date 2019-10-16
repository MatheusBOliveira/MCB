using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MCB.Core.Infra.Data.Mongo.Tests.IoC
{
    public static class Bootstrapper
    {
        public static void RegisterServices(IServiceCollection service, string clienteIdentifier)
        {
            service.AddScoped<IConfiguration>(q =>
            {
                return new ConfigurationBuilder().
                    AddJsonFile("appsettings.json")
                    .Build();
            });
        }
    }
}


