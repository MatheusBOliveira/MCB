using MCB.Core.Infra.CrossCutting.Tests;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;
using Xunit.Abstractions;

namespace MCB.Core.Infra.CrossCutting.ExtensionMethods.Tests
{
    class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public CustomerDetail CustomerDetail { get; set; }

        public Customer()
        {
            CustomerDetail = new CustomerDetail();
        }
    }
    class CustomerDetail
    {
        public string Observation { get; set; }
    }

    public class GenericExtensionMethodsTest
        : TestBase<GenericExtensionMethodsTest>
    {
        public GenericExtensionMethodsTest(ITestOutputHelper output) 
            : base(output)
        {
        }

        protected override void ConfigureServices(IServiceCollection services)
        {

        }

        [Fact]
        [Trait("ExtensionMethods", "CloneTest")]
        public void CloneTest()
        {
            var customer = new Customer
            {
                Id = Guid.NewGuid(),
                Name = "Customer A",
                CustomerDetail = new CustomerDetail
                {
                    Observation = "Observation A"
                }
            };

            var clonedCustomer = customer.Clone();
            clonedCustomer.Id = Guid.NewGuid();
            clonedCustomer.Name = "Customer B";
            clonedCustomer.CustomerDetail.Observation = "Observation B";

            Assert.True(
                customer.Id != clonedCustomer.Id
                && customer.Name != clonedCustomer.Name
                && customer.CustomerDetail.Observation != clonedCustomer.CustomerDetail.Observation
                );
        }
    }
}


