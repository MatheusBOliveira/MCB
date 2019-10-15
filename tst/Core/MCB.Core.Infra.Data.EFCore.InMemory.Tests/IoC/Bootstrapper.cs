using MCB.Core.Infra.CrossCutting.Patterns.UoW.Interfaces;
using MCB.Core.Infra.Data.EFCore.Contexts.Interfaces;
using MCB.Core.Infra.Data.EFCore.InMemory.Tests.Contexts;
using MCB.Core.Infra.Data.EFCore.InMemory.Tests.Repositories;
using MCB.Core.Infra.Data.EFCore.InMemory.Tests.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MCB.Core.Infra.Data.EFCore.InMemory.Tests.IoC
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

            service.AddScoped<IDbContext, TestContext>();
            service.AddTransient<IUnitOfWork, UoW.UnitOfWork>();
            service.AddTransient<ICustomerDataModelRepository, CustomerDataModelRepository>();

        }
    }
}


