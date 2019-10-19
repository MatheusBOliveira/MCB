using MCB.Core.Infra.CrossCutting.Configuration;
using MCB.Core.Infra.CrossCutting.Configuration.Interfaces;
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
        public static void RegisterServices(IServiceCollection services)
        {
            CrossCutting.Configuration.IoC.BootStrapper.RegisterServices(services);

            services.AddScoped<IDbContext, TestContext>();
            services.AddTransient<IUnitOfWork, UoW.UnitOfWork>();
            services.AddTransient<ICustomerDataModelRepository, CustomerDataModelRepository>();

        }
    }
}


