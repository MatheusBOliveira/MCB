using MCB.Core.Infra.CrossCutting.Configuration.Interfaces;
using MCB.Core.Infra.CrossCutting.Tests;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;
using Xunit.Abstractions;

namespace MCB.Core.Infra.CrossCutting.Configuration.Tests
{
    public class ConfiguirationManagerTest
        : TestBase<ConfiguirationManagerTest>
    {
        public ConfiguirationManagerTest(ITestOutputHelper output) 
            : base(output)
        {

        }

        protected override void ConfigureServices(IServiceCollection services)
        {
            IoC.BootStrapper.RegisterServices(services);
        }

        [Fact]
        public void GetPropertyFromDevelopment()
        {
            var config = ServiceProvider.GetService<IConfigurationManager>();
            Assert.Equal("development", config.Get("propertyA"));
        }
        [Fact]
        public void GetPropertyFromDefault()
        {
            var config = ServiceProvider.GetService<IConfigurationManager>();
            Assert.Equal("default", config.Get("propertyB"));
        }
        [Fact]
        public void GetInexistentProperty()
        {
            var config = ServiceProvider.GetService<IConfigurationManager>();
            Assert.True(string.IsNullOrWhiteSpace(config.Get(Guid.NewGuid().ToString())));
        }

        [Fact]
        public void GetNestedPropertyFromDevelopment()
        {
            var config = ServiceProvider.GetService<IConfigurationManager>();
            var propertyValue = config.Get("connectionStrings.default");
            Assert.Equal("development", propertyValue);
        }
        [Fact]
        public void ModifyExistingProperty()
        {
            var config = ServiceProvider.GetService<IConfigurationManager>();

            var propertyName = "propertyC";
            var newValue = "modified value";

            config.Set(propertyName, newValue);

            var getedValue = config.Get(propertyName);

            Assert.Equal(newValue, getedValue);
        }
        [Fact]
        public void AddNewProperty()
        {
            var config = ServiceProvider.GetService<IConfigurationManager>();

            var propertyName = "newProperty";
            var newValue = "new value";

            config.Set(propertyName, newValue);

            var getedValue = config.Get(propertyName);

            Assert.Equal(newValue, getedValue);
        }
    }
}
