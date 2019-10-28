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
    public static class DefaultBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            CrossCutting.Configuration.IoC.DefaultBootstrapper.RegisterServices(services);

            services.AddScoped<IDbContext, TestContext>();
            services.AddTransient<IUnitOfWork, UoW.UnitOfWork>();
            services.AddTransient<ICustomerDataModelRepository, CustomerDataModelRepository>();

        }
    }
}


