using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit.Abstractions;

namespace MCB.Core.Infra.CrossCutting.Tests
{
    public abstract class TestBase<T>
    {
        protected IServiceProvider ServiceProvider { get; }
        public ITestOutputHelper Output { get; }

        protected TestBase(ITestOutputHelper output)
        {
            Output = output;
            var service = new ServiceCollection();

            ConfigureServices(service);
            ServiceProvider = service.BuildServiceProvider();
        }

        protected abstract void ConfigureServices(IServiceCollection service);
    }
}


