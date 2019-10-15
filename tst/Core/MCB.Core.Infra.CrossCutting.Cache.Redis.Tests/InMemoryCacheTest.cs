using MCB.Core.Infra.CrossCutting.Cache.Redis.Interfaces;
using MCB.Core.Infra.CrossCutting.Cache.Redis.Tests.Models;
using MCB.Core.Infra.CrossCutting.Tests;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using MCB.Core.Infra.CrossCutting.ExtensionMethods;
using Xunit.Abstractions;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace MCB.Core.Infra.CrossCutting.Cache.Redis.Tests
{
    public class RedisCacheTest
        : TestBase<RedisCacheTest>
    {
        private IRedisCache _cache;

        public RedisCacheTest(ITestOutputHelper output) 
            : base(output)
        {
            _cache = ServiceProvider.GetService<IRedisCache>();
        }

        protected override void ConfigureServices(IServiceCollection service)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            service.AddSingleton<IConfiguration>(config);
            IoC.BootStrapper.RegisterServices(service, null, config);
        }

        [Fact]
        [Trait("RedisCache", "AddOrUpdate")]
        public async Task AddOrUpdate()
        {
            var key = "AddOrUpdate";
            var value = "DOUTOVILHA";

            // Add
            _cache.AddOrUpdate(key, "value to be replaced");
            // Update
            _cache.AddOrUpdate(key, value);

            var retrievedValue = await _cache.GetAsync(key);

            Assert.Equal(value, retrievedValue);
        }

        [Fact]
        [Trait("RedisCache", "Delete")]
        public async Task Delete()
        {
            var key = "Delete";
            var value = "DOUTOVILHA";

            // Add
            _cache.AddOrUpdate(key, value);
            // Delete
            _cache.Delete(key);

            var retrievedValue = await _cache.GetAsync(key);

            Assert.NotEqual(value, retrievedValue);
        }

        [Fact]
        [Trait("RedisCache", "Get")]
        public async Task Get()
        {
            var key = "Get";
            var value = "DOUTOVILHA";

            // Add
            _cache.AddOrUpdate(key, value);

            var retrievedValue = await _cache.GetAsync(key);

            Assert.Equal(value, retrievedValue);
        }

        [Fact]
        [Trait("RedisCache", "GetGeneric")]
        public async Task GetGeneric()
        {
            var key = "GetGeneric";
            var value = new Customer {
                Name = "Marcelo Castelo Branco",
                EmailAddress = "marcelo.castelo@outlook.com"
            };

            // Add
            _cache.AddOrUpdate(key, value.SerializeToJson());

            var retrievedCustomer = await _cache.GetAsync<Customer>(key);

            Assert.True(
                value.Name.Equals(retrievedCustomer.Name)
                && value.EmailAddress.Equals(retrievedCustomer.EmailAddress));
        }

        [Fact]
        [Trait("RedisCache", "GetAll")]
        public async Task GetAll()
        {
            var key1 = "GetAll_1";
            var key2 = "GetAll_2";

            var value1 = "Value_1";
            var value2 = "Value_2";

            var retrivied1 = string.Empty;
            var retrivied2 = string.Empty;

            _cache.AddOrUpdate(key1, value1);
            _cache.AddOrUpdate(key2, value2);

            var allEntries = await _cache.GetAllAsync();

            allEntries.TryGetValue(key1, out retrivied1);
            allEntries.TryGetValue(key2, out retrivied2);

            Assert.True(
                value1.Equals(retrivied1)
                && value2.Equals(retrivied2));
        }
    }
}


