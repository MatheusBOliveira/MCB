using MCB.Core.Infra.CrossCutting.Configuration.Interfaces;
using MCB.Core.Infra.CrossCutting.Tests;
using MCB.Core.Infra.Data.EFCore.InMemory.Tests.Contexts;
using MCB.Core.Infra.Data.EFCore.InMemory.Tests.DataModels;
using MCB.Core.Infra.Data.EFCore.InMemory.Tests.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace MCB.Core.Infra.Data.EFCore.InMemory.Tests
{
    public class InMemoryTest
        : TestBase<InMemoryTest>
    {
        public InMemoryTest(ITestOutputHelper output)
            : base(output)
        {

        }

        protected override void ConfigureServices(IServiceCollection services)
        {
            IoC.Bootstrapper.RegisterServices(services);
        }

        private CustomerDataModel CreateNewCustomer()
        {
            var newCustomerDataModel = new CustomerDataModel
            {
                Id = Guid.NewGuid(),
                Name = $"New Customer {DateTime.UtcNow}",
                ActivationDate = DateTime.UtcNow,
                ActivationUser = "testUser",
                IsActive = true,
                CreatedDate = DateTime.UtcNow,
                CreatedUser = "testUser"
            };

            return newCustomerDataModel;
        }

        [Fact]
        [Trait("InMemoryTest", "AddTest")]
        public async Task AddTest()
        {
            var success = false;
            var config = ServiceProvider.GetService<IConfigurationManager>();

            using (var context = new TestContext(config))
            {
                using (var repository = new CustomerDataModelRepository(context))
                {
                    await repository.AddAsync(CreateNewCustomer());
                    success = await context.SaveChangesAsync() > 0;
                }
            }

            Assert.True(success);
        }

        [Fact]
        [Trait("InMemoryTest", "Update")]
        public async Task UpdateTest()
        {
            var success = false;
            var config = ServiceProvider.GetService<IConfigurationManager>();

            await AddTest();

            using (var context = new TestContext(config))
            {
                using (var repository = new CustomerDataModelRepository(context))
                {
                    var getAllResult = await repository.GetAllAsync();
                    var customerDataModel = getAllResult.FirstOrDefault();
                    customerDataModel.Name = "Updated name";

                    await repository.UpdateAsync(customerDataModel);

                    success = await context.SaveChangesAsync() > 0;
                }
            }

            Assert.True(success);
        }

        [Fact]
        [Trait("InMemoryTest", "Remove")]
        public async Task RemoveTest()
        {
            var success = false;
            var config = ServiceProvider.GetService<IConfigurationManager>();

            await AddTest();

            using (var context = new TestContext(config))
            {
                using (var repository = new CustomerDataModelRepository(context))
                {
                    var getAllResult = await repository.GetAllAsync();
                    var customerDataModel = getAllResult.FirstOrDefault();
                    await repository.RemoveAsync(customerDataModel.Id);

                    success = await context.SaveChangesAsync() > 0;
                }
            }

            Assert.True(success);
        }

        [Fact]
        [Trait("InMemoryTest", "AddPerformanceTest")]
        public async Task AddPerformanceTest()
        {
            var success = false;

            var config = ServiceProvider.GetService<IConfigurationManager>();

            using (var context = new TestContext(config))
            {
                using (var repository = new CustomerDataModelRepository(context))
                {
                    for (int i = 0; i < 100; i++)
                    {
                        await repository.AddAsync(CreateNewCustomer());

                        success = await context.SaveChangesAsync() > 0;
                    }
                }
            }

            Assert.True(success);
        }
    }
}


