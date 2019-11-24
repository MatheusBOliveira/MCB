using MCB.Core.Infra.CrossCutting.Patterns.Retry.BackoffAlgorithm.Base;
using MCB.Core.Infra.CrossCutting.Patterns.Retry.BackoffAlgorithm.Enums;
using MCB.Core.Infra.CrossCutting.Patterns.Retry.BackoffAlgorithm.Factories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Patterns.Retry
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// see https://medium.com/@trongdan_tran/circuit-breaker-and-retry-64830e71d0f6
    /// </remarks>
    public class RetryPolicy
    {
        private readonly int _millisecondsTimeout;
        private readonly int _maxAttempts;
        private readonly Func<bool> _executionFunction;
        private readonly BackoffAlgorithmTypeEnum _backoffAlgorithmType;
        private readonly BackoffAlgorithmBase _backoffAlgorithmBase;

        public int MillisecondsTimeout
        {
            get
            {
                return _millisecondsTimeout;
            }
        }
        public int MaxAttempts
        {
            get
            {
                return _maxAttempts;
            }
        }

        public RetryPolicy(
            Func<bool> executionFunction,
            CultureInfo culture,
            int maxAttempts = 3,
            int millisecondsTimeout = 1000,
            BackoffAlgorithmTypeEnum backoffAlgorithmType = BackoffAlgorithmTypeEnum.None)
        {
            _millisecondsTimeout = millisecondsTimeout;
            _maxAttempts = maxAttempts;
            _executionFunction = executionFunction;
            _backoffAlgorithmType = backoffAlgorithmType;

            _backoffAlgorithmBase = new BackoffAlgorithmFactory().Create(_backoffAlgorithmType, culture);
        }

        public async Task<bool> Execute(CancellationToken cancellationToken)
        {
            var attempt = 1;

            while (true)
            {
                if (cancellationToken.IsCancellationRequested)
                    return await Task.FromResult(false);

                // Try execution
                if(_executionFunction.Invoke())
                    return await Task.FromResult(true);

                // Check Max Attempts
                if(attempt >= MaxAttempts)
                    return await Task.FromResult(false);

                // Get retry timeout
                var retryTimeout = _backoffAlgorithmBase.GetRetryTimeout(attempt, this, cancellationToken);

                Thread.Sleep(retryTimeout);

                attempt++;
            }
        }
    }
}
