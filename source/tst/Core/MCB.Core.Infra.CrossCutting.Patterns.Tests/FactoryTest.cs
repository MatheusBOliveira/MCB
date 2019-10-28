using MCB.Core.Infra.CrossCutting.Patterns.Tests.Commands;
using MCB.Core.Infra.CrossCutting.Patterns.Tests.Factories.DomainModels;
using MCB.Core.Infra.CrossCutting.Tests;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;
using Xunit.Abstractions;

namespace MCB.Core.Infra.CrossCutting.Patterns.Tests
{
    public class FactoryTest
        : TestBase<FactoryTest>
    {
        public FactoryTest(ITestOutputHelper output) : base(output)
        {

        }

        protected override void ConfigureServices(IServiceCollection services)
        {

        }
        protected override void ServiceProviderGenerated(IServiceProvider serviceProvider)
        {

        }

        [Fact]
        [Trait("Patterns", "FactoryDefaultTest")]
        public void FactoryDefaultTest()
        {
            var registerNewCustomerCommand = new RegisterNewCustomerCommand
            {
                Name = "Marcelo Castelo Branco",
                Password = "123456",
                Email = "marcelo.castelo@outlook.com"
            };

            var customer = new CustomerFactory().
                Create(registerNewCustomerCommand);

            var user = new UserFactory().
                Create(registerNewCustomerCommand);

            Assert.True(
               customer.Name == registerNewCustomerCommand.Name
               && customer.Email == registerNewCustomerCommand.Email
               && user.Username == registerNewCustomerCommand.Email
               && user.Password == registerNewCustomerCommand.Password
               );
        }
    }
}


