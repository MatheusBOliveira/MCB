using MCB.Core.Infra.CrossCutting.Tests;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;
using Xunit.Abstractions;

namespace MCB.Core.Infra.CrossCutting.ExtensionMethods.Tests
{
    public class DateTimeExtensionMethodsTest
        : TestBase<DateTimeExtensionMethodsTest>
    {
        public DateTimeExtensionMethodsTest(ITestOutputHelper output) 
            : base(output)
        {
        }

        protected override void ConfigureServices(IServiceCollection services)
        {

        }
        protected override void ServiceProviderGenerated(IServiceProvider serviceProvider)
        {

        }

        [Fact]
        [Trait("ExtensionMethods", "IsBetween")]
        public void IsBetween()
        {
            var today = DateTime.UtcNow;
            var yesterday = DateTime.UtcNow.AddDays(-1);
            var tomorrow = DateTime.UtcNow.AddDays(1);

            Assert.True(today.IsBetween(yesterday, tomorrow));
        }
    }
}


