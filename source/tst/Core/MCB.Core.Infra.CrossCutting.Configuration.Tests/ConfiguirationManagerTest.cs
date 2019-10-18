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
        public void Test1()
        {
            var config = _configurationManager.Get<int>("propriedadeA");
        }
    }
}
