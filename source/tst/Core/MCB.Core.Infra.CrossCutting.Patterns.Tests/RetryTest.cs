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
        [Trait("Patterns", "RetrySuccessTest")]
        public async System.Threading.Tasks.Task RetrySuccessTest()
        {
            var attempt = 0;
            var maxAttemps = 3;

            var testFunction = new Func<bool>(() => {
                
                attempt++;

                return attempt == maxAttemps;

            });

            var retryPolicy = new RetryPolicy(
                testFunction, 
                CultureInfo,
                maxAttempts: maxAttemps,
                backoffAlgorithmType: Retry.BackoffAlgorithm.Enums.BackoffAlgorithmTypeEnum.None);

            var executionResult = await retryPolicy.Execute(new System.Threading.CancellationToken());

            Assert.True(executionResult && attempt == maxAttemps);
        }

        [Fact]
        [Trait("Patterns", "RetryFailTest")]
        public async System.Threading.Tasks.Task RetryFailTest()
        {
            var attempt = 0;
            var maxAttemps = 3;

            var testFunction = new Func<bool>(() => {

                attempt++;

                return false;
            });

            var retryPolicy = new RetryPolicy(
                testFunction,
                CultureInfo,
                maxAttempts: maxAttemps,
                backoffAlgorithmType: Retry.BackoffAlgorithm.Enums.BackoffAlgorithmTypeEnum.None);

            var executionResult = await retryPolicy.Execute(new System.Threading.CancellationToken());

            Assert.True(!executionResult && attempt == maxAttemps);
        }
    }
}
