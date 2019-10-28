using MCB.Core.Domain.Factories.ValueObjects;
using MCB.Core.Domain.Factories.ValueObjects.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Core.Domain.IoC
{
    public static class DefaultBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            RegisterFactories(services);
        }

        private static void RegisterFactories(IServiceCollection services)
        {
            services.AddScoped<IEmailValueObjectFactory, EmailValueObjectFactory>();
        }
    }
}
