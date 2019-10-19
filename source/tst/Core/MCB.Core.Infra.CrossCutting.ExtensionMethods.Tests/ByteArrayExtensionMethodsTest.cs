using System;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;
using MCB.Core.Infra.CrossCutting.Tests;

namespace MCB.Core.Infra.CrossCutting.ExtensionMethods.Tests
{
    public class ByteArrayExtensionMethodsTest
        : TestBase<ByteArrayExtensionMethodsTest>
    {
        public ByteArrayExtensionMethodsTest(ITestOutputHelper output) 
            : base(output)
        {
        }

        protected override void ConfigureServices(IServiceCollection services)
        {

        }

        [Fact]
        [Trait("ExtensionMethods", "IsGreatherThanTest")]
        public void IsGreatherThanTest()
        {
            var minValue = BitConverter.GetBytes(1);
            var otherMinValue = BitConverter.GetBytes(1);
            var maxValue = BitConverter.GetBytes(2);

            var test1bool = maxValue.IsGreaterThan(minValue);
            var test2bool = minValue.IsGreaterThan(maxValue);
            var teste3bool = minValue.IsGreaterThan(otherMinValue);

            Assert.True(test1bool && !test2bool && !teste3bool);
        }
    }
}


