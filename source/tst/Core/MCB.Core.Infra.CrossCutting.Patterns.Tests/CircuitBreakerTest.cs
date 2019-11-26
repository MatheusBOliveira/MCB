using MCB.Core.Infra.CrossCutting.Patterns.CircuitBreaker;
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
    public class CircuitBreakerTest
        : TestBase<CircuitBreakerTest>
    {
        public CircuitBreakerTest(ITestOutputHelper output)
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
        [Trait("Patterns", "CircuitBreakerSuccessTest")]
        public async System.Threading.Tasks.Task CircuitBreakerSuccessTest()
        {
            var attempts = 0;
            var maxAttemps = 3;

            var maxOfOpenedEvent = 4;
            var maxOfHalfOpenedEvent = 4;

            var totalOfOpenedEvent = 0;
            var totalOfHalfOpenedEvent = 0;
            var totalOfRetryAttemps = 0;

            var testFunction = new Func<bool>(() =>
            {
                attempts++;

                return maxOfOpenedEvent == totalOfOpenedEvent
                    && maxOfHalfOpenedEvent == totalOfHalfOpenedEvent;
            });

            var retryPolicy = new RetryPolicy(
                testFunction,
                CultureInfo,
                maxAttempts: maxAttemps,
                backoffAlgorithmType: Retry.BackoffAlgorithm.Enums.BackoffAlgorithmTypeEnum.None);
            
            retryPolicy.ExecutionFailedEvent += (RetryPolicy retryPolicy, int attempt, Exception ex) => 
            {
                Output.WriteLine("ExecutionFailedEvent");
                totalOfRetryAttemps++;
            };

            var circuitBreakerPolicy = new CircuitBreakerPolicy(
                retryPolicy,
                3_000);

            circuitBreakerPolicy.CircuitOpenedEvent += (policy) =>
            {
                Output.WriteLine("CircuitOpenedEvent");
                totalOfOpenedEvent++;
            };
            circuitBreakerPolicy.CircuitHalfOpenedEvent += (policy) =>
            {
                Output.WriteLine("CircuitHalfOpenedEvent");
                totalOfHalfOpenedEvent++;
            };
            circuitBreakerPolicy.CircuitClosedEvent += (policy) =>
            {
                Output.WriteLine("CircuitClosedEvent");
            };

            var executionResult = false;

            while (!executionResult)
            {
                executionResult = await circuitBreakerPolicy.Execute(new System.Threading.CancellationToken());
            }

            /*
             * 13 = 3 times per retry policy per halfopened + first execution = (3 * 4) + 1
             */
            Assert.True(executionResult && totalOfRetryAttemps == 13);
        }
    }
}
