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
            Assert.Equal("development", _configurationManager.Get("propriedadeA"));
        }
        [Fact]
        public void GetPropertyFromDefault()
        {
            Assert.Equal("default", _configurationManager.Get("propriedadeB"));
        }

        [Fact]
        public void ModifyExistingProperty()
        {
            var newValue = "modified value";

            _configurationManager.Set("propriedadeC", newValue);

            var getedValue = _configurationManager.Get("propriedadeC");

            Assert.Equal(newValue, getedValue);
        }
    }
}
