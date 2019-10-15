using MCB.Core.Infra.CrossCutting.Tests;
using MCB.Core.Infra.Data.Mongo.Tests.Contexts;
using MCB.Core.Infra.Data.Mongo.Tests.DataModels;
using MCB.Core.Infra.Data.Mongo.Tests.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace MCB.Core.Infra.Data.Mongo.Tests
{
    public class MongoTest
        : TestBase<MongoTest>
    {
        private readonly IConfiguration _configration;

        public MongoTest(ITestOutputHelper output)
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
            var customerId = Guid.NewGuid().ToString();

            var newCustomerDataModel = new CustomerDataModel
            {
                DataModelId = customerId,
                Name = $"New Customer {DateTime.UtcNow}",
                ActivationDate = DateTime.UtcNow,
                ActivationUser = "testUser",
                IsActive = true,
                CreatedDate = DateTime.UtcNow,
                CreatedUser = "testUser",
                AppointmentCollection = new List<AppointmentDataModel>
                {
                    new AppointmentDataModel
                    {
                        DataModelId = Guid.NewGuid().ToString(),
                        CustomerId = customerId,
                        Date = DateTime.UtcNow,
                        Observation = $"Observation created at {DateTime.UtcNow}",
                        CreatedDate = DateTime.UtcNow,
                        CreatedUser = "testUser"
                    }
                }
            };

            return newCustomerDataModel;
        }

        [Fact]
        [Trait("MongoTest", "AddTest")]
        public async Task<string> AddTest()
        {
            var success = false;
            var newCustomer = CreateNewCustomer();

            using (var context = new TestContext(_configration))
            {
                context.CreateConnection();

                using (var customerDataModelRepository = new CustomerDataModelRepository(context))
                {
                    await customerDataModelRepository.AddAsync(newCustomer);
                    var addedCustomer = await customerDataModelRepository.GetByIdAsync(
                        Guid.Parse(newCustomer.DataModelId));

                    success = newCustomer.DataModelId == addedCustomer.DataModelId;
                }
            }

            Assert.True(success);

            return await Task.FromResult(newCustomer.DataModelId);
        }

        [Fact]
        [Trait("MongoTest", "Update")]
        public async Task UpdateTest()
        {
            var success = false;

            //var customerId = await AddTest();
            var customerId = await AddTest();
            var newName = "Updated name";

            using (var context = new TestContext(_configration))
            {
                context.CreateConnection();

                using (var customerDataModelRepository = new CustomerDataModelRepository(context))
                {

                    var customerDataModel = new CustomerDataModel
                    {
                        DataModelId = customerId.ToString(),
                        Name = newName
                    };

                    await customerDataModelRepository.UpdateAsync(customerDataModel);

                    var alteredCustomer = await customerDataModelRepository.GetByIdAsync(
                        Guid.Parse(customerId)
                        );

                    success = alteredCustomer.Id == Guid.Parse(customerId)
                        && alteredCustomer.Name.Equals(newName);
                }
            }

            Assert.True(success);
        }

        [Fact]
        [Trait("MongoTest", "Remove")]
        public async Task RemoveTest()
        {
            var success = false;

            var customerId = await AddTest();

            using (var context = new TestContext(_configration))
            {
                context.CreateConnection();

                using (var customerDataModelRepository = new CustomerDataModelRepository(context))
                {

                    var customerDataModel = new CustomerDataModel
                    {
                        DataModelId = customerId
                    };

                    await customerDataModelRepository.RemoveAsync(Guid.Parse(customerId));

                    var deletedCUstomer = await customerDataModelRepository.GetByIdAsync(Guid.Parse(customerId));

                    success = deletedCUstomer == null;
                }
            }

            Assert.True(success);
        }

        [Fact]
        [Trait("MongoTest", "AddPerformanceTest")]
        public async Task AddPerformanceTest()
        {
            for (int i = 0; i < 100; i++)
                await AddTest();

            Assert.True(true);
        }
    }
}


