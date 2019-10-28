using MCB.Core.Infra.CrossCutting.Patterns.Tests.Adapters.DomainModels;
using MCB.Core.Infra.CrossCutting.Patterns.Tests.Commands;
using MCB.Core.Infra.CrossCutting.Patterns.Tests.DomainModels;
using MCB.Core.Infra.CrossCutting.Tests;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;
using Xunit.Abstractions;

namespace MCB.Core.Infra.CrossCutting.Patterns.Tests
{
    public class AdapterTest
        : TestBase<AdapterTest>
    {
        public AdapterTest(ITestOutputHelper output) 
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
        [Trait("Patterns", "AdaptTest")]
        public void AdaptTest()
        {
            var registerNewCustomerCommand = new RegisterNewCustomerCommand
            {
                Name = "Marcelo Castelo Branco",
                Password = "123456",
                Email = "marcelo.castelo@outlook.com"
            };

            var customer = new CustomerAdapter().Adapt(
                new Customer(),
                registerNewCustomerCommand);
            var user = new UserAdapter().Adapt(
                new User(),
                registerNewCustomerCommand);

            Assert.True(
                customer.Name == registerNewCustomerCommand.Name
                && customer.Email == registerNewCustomerCommand.Email
                && user.Username == registerNewCustomerCommand.Email
                && user.Password == registerNewCustomerCommand.Password
                );
        }
    }
}


