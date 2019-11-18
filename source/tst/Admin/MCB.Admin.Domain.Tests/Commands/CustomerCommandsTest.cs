using MCB.Admin.Domain.Commands.Customers;
using MCB.Core.Domain.Factories.ValueObjects.Interfaces;
using MCB.Core.Domain.ValueObjects;
using MCB.Core.Domain.ValueObjects.Enums;
using MCB.Core.Domain.ValueObjects.Localization;
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
        [Trait("Admin.Domain", "RegisterNewCustomerCommandTest")]
        public async Task RegisterNewCustomerCommandTest()
        {
            try
            {
                var registerNewCustomerCommand = new RegisterNewCustomerCommand
                {
                    ApplicationName = "MCB Scheduler",
                    CultureInfo = CultureInfo,
                    Email = new EmailValueObject { EmailAddress = "marcelo.castelo@outlook.com" },
                    GovernamentalNumber = new CPFValueObject() { DocumentNumber = "740.154.950-63" },
                    Name = "Marcelo Castelo Branco",
                    Password = new PasswordValueObject("trocar@123"),
                    Username = "MarceloCas",
                    PhoneNumber = new PhoneNumberValueObject(PhoneNumberTypeEnum.Principal, "+55", "15", "981902276")
                };

                var result = await _sagaManager.SendCommand<RegisterNewCustomerCommand, bool>(registerNewCustomerCommand, CultureInfo, new System.Threading.CancellationToken());

                Assert.True(result.Success);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
