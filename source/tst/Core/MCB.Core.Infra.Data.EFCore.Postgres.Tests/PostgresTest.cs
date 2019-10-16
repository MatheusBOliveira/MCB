using MCB.Core.Infra.CrossCutting.Tests;
using MCB.Core.Infra.Data.EFCore.Postgres.Tests.Contexts;
using MCB.Core.Infra.Data.EFCore.Postgres.Tests.DataModels;
using MCB.Core.Infra.Data.EFCore.Postgres.Tests.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace MCB.Core.Infra.Data.EFCore.Postgres.Tests
{
    public class PostgresTest
        : TestBase<PostgresTest>
    {
        private readonly IConfiguration _configration;

        public PostgresTest(ITestOutputHelper output)
            : base(output)
        {
            _configration = ServiceProvider.GetService<IConfiguration>();
        }

        protected override void ConfigureServices(IServiceCollection service)
        {
            IoC.Bootstrapper.RegisterServices(service, null);
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
        [Trait("PostgresTest", "AddTest")]
        public async Task<Guid> AddTest()
        {
            var success = false;
            var newCustomer = CreateNewCustomer();

            using (var context = new TestContext(_configration))
            {
                using (var customerDataModelRepository = new CustomerDataModelRepository(context))
                {
                    await customerDataModelRepository.AddAsync(newCustomer);

                    success = await context.SaveChangesAsync() > 0;
                }
            }

            Assert.True(success);

            return await Task.FromResult(newCustomer.Id);
        }

        [Fact]
        [Trait("PostgresTest", "Update")]
        public async Task UpdateTest()
        {
            var success = false;

            var customerId =  await AddTest();
            var alteredCustomer = default(CustomerDataModel);
            var newName = "Updated name";

            using (var context = new TestContext(_configration))
            {
                using (var customerDataModelRepository = new CustomerDataModelRepository(context))
                {

                    var customerDataModel = new CustomerDataModel
                    {
                        Id = customerId,
                        Name = newName
                    };

                    await customerDataModelRepository.UpdateAsync(customerDataModel);

                    success = await context.SaveChangesAsync() > 0;
                    if (!success)
                        Assert.True(false);

                    alteredCustomer = await customerDataModelRepository.GetByIdAsync(customerId);

                    success = alteredCustomer.Id == customerId
                        && alteredCustomer.Name.Equals(newName);
                }
            }

            Assert.True(success);
        }

        [Fact]
        [Trait("PostgresTest", "Remove")]
        public async Task RemoveTest()
        {
            var success = false;

            var customerId = await AddTest();

            using (var context = new TestContext(_configration))
            {
                using (var customerDataModelRepository = new CustomerDataModelRepository(context))
                {

                    var customerDataModel = new CustomerDataModel
                    {
                        Id = customerId
                    };

                    await customerDataModelRepository.RemoveAsync(customerId);

                    success = await context.SaveChangesAsync() > 0;
                }
            }

            Assert.True(success);
        }

        [Fact]
        [Trait("PostgresTest", "AddPerformanceTest")]
        public async Task AddPerformanceTest()
        {
            for (int i = 0; i < 100; i++)
                await AddTest();

            Assert.True(true);
        }
    }
}


