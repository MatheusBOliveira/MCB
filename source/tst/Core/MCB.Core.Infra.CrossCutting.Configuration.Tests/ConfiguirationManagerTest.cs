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
        private readonly ConfigurationManager _configurationManager;

        public ConfiguirationManagerTest(ITestOutputHelper output) 
            : base(output)
        {
            _configurationManager = new ConfigurationManager();
            _configurationManager.LoadConfigurations();
        }

        protected override void ConfigureServices(IServiceCollection service)
        {

        }

        [Fact]
        public void GetPropertyFromDevelopment()
        {
            Assert.Equal("development", _configurationManager.Get("propertyA"));
        }
        [Fact]
        public void GetPropertyFromDefault()
        {
            Assert.Equal("default", _configurationManager.Get("propertyB"));
        }
        [Fact]
        public void GetInexistentProperty()
        {
            Assert.True(string.IsNullOrWhiteSpace(_configurationManager.Get(Guid.NewGuid().ToString())));
        }

        [Fact]
        public void GetNestedPropertyFromDevelopment()
        {
            var propertyValue = _configurationManager.Get("connectionStrings.default");
            Assert.Equal("development", propertyValue);
        }
        [Fact]
        public void ModifyExistingProperty()
        {
            var propertyName = "propertyC";
            var newValue = "modified value";

            _configurationManager.Set(propertyName, newValue);

            var getedValue = _configurationManager.Get(propertyName);

            Assert.Equal(newValue, getedValue);
        }
        [Fact]
        public void AddNewProperty()
        {
            var propertyName = "newProperty";
            var newValue = "new value";

            _configurationManager.Set(propertyName, newValue);

            var getedValue = _configurationManager.Get(propertyName);

            Assert.Equal(newValue, getedValue);
        }
    }
}
