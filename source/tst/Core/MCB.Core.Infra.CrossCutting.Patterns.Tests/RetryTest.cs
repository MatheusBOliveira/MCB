using MCB.Core.Infra.CrossCutting.Patterns.Retry;
using MCB.Core.Infra.CrossCutting.Tests;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace MCB.Core.Infra.CrossCutting.Patterns.Tests
{
    public class RetryTest
        : TestBase<RetryTest>
    {
        public RetryTest(ITestOutputHelper output) 
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
        [Trait("Patterns", "RetryTest")]
        public async System.Threading.Tasks.Task RetryDecorrJitterTestAsync()
        {
            var attempt = 0;

            var testFunction = new Func<bool>(() => {
                
                attempt++;

                return attempt == 10;

            });

            var retryPolicy = new RetryPolicy(
                testFunction, 
                CultureInfo,
                maxAttempts: 10,
                backoffAlgorithmType: Retry.BackoffAlgorithm.Enums.BackoffAlgorithmTypeEnum.None);

            var executionResult = await retryPolicy.Execute(new System.Threading.CancellationToken());

            Assert.True(executionResult);
        }
    }
}
