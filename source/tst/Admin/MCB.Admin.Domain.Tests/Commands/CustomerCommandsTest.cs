using MCB.Admin.Domain.Commands.Customers;
using MCB.Core.Domain.Factories.ValueObjects.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Saga.Interfaces;
using MCB.Core.Infra.CrossCutting.Tests;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace MCB.Admin.Domain.Tests.Commands
{
    public class CustomerCommandsTest
        : TestBase<CustomerCommandsTest>
    {
        private ISagaManager _sagaManager;

        private IEmailValueObjectFactory _emailValueObjectValue;

        public CustomerCommandsTest(ITestOutputHelper output) 
            : base(output)
        {

        }

        protected override void ConfigureServices(IServiceCollection services)
        {
            IoC.DefaultBootstrapper.RegisterServices(services);
        }
        protected override void ServiceProviderGenerated(IServiceProvider serviceProvider)
        {
            _sagaManager = serviceProvider.GetService<ISagaManager>();
            _emailValueObjectValue = serviceProvider.GetService<IEmailValueObjectFactory>();
        }

        [Fact]
        [Trait("Admin.Domain", "ActiveCustomerCommandTest")]
        public async Task ActiveCustomerCommandTest()
        {
            try
            {
                var activateCustomerCommand = new ActiveCustomerCommand
                {
                    Username = "marcelo.castelo",
                    Email = null
                };

                var result = await _sagaManager.SendCommand<ActiveCustomerCommand, bool>(activateCustomerCommand, CultureInfo, new System.Threading.CancellationToken());
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
