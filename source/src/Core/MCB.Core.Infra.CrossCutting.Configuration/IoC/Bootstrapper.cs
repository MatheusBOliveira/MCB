using MCB.Core.Infra.CrossCutting.Configuration.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Core.Infra.CrossCutting.Configuration.IoC
{
    public static class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IConfigurationManager>(q => {
                var config = new ConfigurationManager();
                config.LoadConfigurations();

                return config;
            });
        }
    }
}
