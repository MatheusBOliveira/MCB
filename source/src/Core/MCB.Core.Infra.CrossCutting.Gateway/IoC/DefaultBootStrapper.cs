using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Core.Infra.CrossCutting.Gateway.IoC
{
    public static class DefaultBootstrapper
    {
        public static void RegisterServices(IServiceCollection services, string[] jsonFilesArray)
        {
            services.AddSingleton(q =>
            {
                var gatewayManager = new GatewayManager();
                gatewayManager.LoadJsonFiles(jsonFilesArray);

                return gatewayManager;
            });
        }
    }
}
