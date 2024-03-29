using MCB.Core.Infra.CrossCutting.Tests;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;
using Xunit.Abstractions;

namespace MCB.Core.Infra.CrossCutting.ExtensionMethods.Tests
{
    public class ObjectExtensionMethodsTest
        : TestBase<ObjectExtensionMethodsTest>
    {
        public ObjectExtensionMethodsTest(ITestOutputHelper output) 
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
        [Trait("ExtensionMethods", "SerializeToJsonTest")]
        public void SerializeToJsonTest()
        {
            var customer = new
            {
                name = "Marcelo Castelo Branco",
                email = "marcelo.castelo@outlook.com"
            };

            var json = @"{ ""name"": ""Marcelo Castelo Branco"", ""email"": ""marcelo.castelo@outlook.com"" }";
            var customerSerialized = customer.SerializeToJson();

            json = json.Replace(" ", string.Empty).ToLower();
            customerSerialized = customerSerialized.Replace(" ", string.Empty).ToLower();

            Assert.Equal(json, customerSerialized);
        }
    }
}


