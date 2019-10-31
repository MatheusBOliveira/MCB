using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;
using Xunit.Abstractions;

namespace MCB.Core.Infra.CrossCutting.Tests
{
    public abstract class TestBase<T>
    {
        protected CultureInfo CultureInfo { get; set; }
        protected IServiceProvider ServiceProvider { get; }
        public ITestOutputHelper Output { get; }


        protected TestBase(ITestOutputHelper output)
        {
            CultureInfo = new CultureInfo("en-US");
            Output = output;
            var service = new ServiceCollection();

            ConfigureServices(service);
            ServiceProvider = service.BuildServiceProvider();
            ServiceProviderGenerated(ServiceProvider);
        }

        protected abstract void ConfigureServices(IServiceCollection services);
        protected abstract void ServiceProviderGenerated(IServiceProvider serviceProvider);
    }
}


