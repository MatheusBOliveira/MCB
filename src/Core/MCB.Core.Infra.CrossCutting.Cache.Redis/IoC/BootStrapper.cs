using MCB.Core.Infra.CrossCutting.Cache.Redis.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace MCB.Core.Infra.CrossCutting.Cache.Redis.IoC
{
    public static class BootStrapper
    {
        public static void RegisterServices(
            IServiceCollection services, 
            string clienteIdentifier,
            IConfiguration config)
        {
            services.AddSingleton(q =>
                ConnectionMultiplexer.Connect(config["redis:server"]));
            services.AddScoped<IRedisCache, RedisCache>();

        }
    }
}


