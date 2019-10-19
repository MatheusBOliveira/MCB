using MCB.Core.Infra.CrossCutting.Configuration;
using MCB.Core.Infra.CrossCutting.Configuration.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.UoW.Interfaces;
using MCB.Core.Infra.Data.EFCore.Contexts.Interfaces;
using MCB.Core.Infra.Data.EFCore.Postgres.Tests.Contexts;
using MCB.Core.Infra.Data.EFCore.Postgres.Tests.Repositories;
using MCB.Core.Infra.Data.EFCore.Postgres.Tests.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MCB.Core.Infra.Data.EFCore.Postgres.Tests.IoC
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

            service.AddScoped<IDbContext, TestContext>();
            service.AddTransient<IUnitOfWork, UoW.UnitOfWork>();
            service.AddTransient<ICustomerDataModelRepository, CustomerDataModelRepository>();

        }
    }
}


