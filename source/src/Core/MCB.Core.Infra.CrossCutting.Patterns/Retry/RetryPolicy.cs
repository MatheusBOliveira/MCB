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
        public Func<bool> ExecutionFunction
        {
            get
            {
                return _executionFunction;
            }
        }
        public BackoffAlgorithmTypeEnum BackoffAlgorithmType
        {
            get
            {
                return _backoffAlgorithmType;
            }
        }
        public BackoffAlgorithmBase BackoffAlgorithmBase
        {
            get
            {
                return _backoffAlgorithmBase;
            }
        }

        public delegate void ExecutionFailedHandler(RetryPolicy retryPolicy, int attempt, Exception ex);
        public delegate void MaxAttemptsExceededHandler(RetryPolicy retryPolicy);

        public event ExecutionFailedHandler ExecutionFailedEvent;
        public event MaxAttemptsExceededHandler MaxAttemptsExceededEvent;

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
                var executionReturn = false;

                try
                {
                    executionReturn = ExecutionFunction.Invoke();

                    if (executionReturn)
                        return await Task.FromResult(true);

                    ExecutionFailedEvent?.Invoke(this, attempt, null);
                }
                catch (Exception ex)
                {
                    executionReturn = false;
                    ExecutionFailedEvent?.Invoke(this, attempt, ex);
                }


                // Check Max Attempts
                if (attempt >= MaxAttempts)
                {
                    MaxAttemptsExceededEvent?.Invoke(this);
                    return await Task.FromResult(false);
                }
                // Get retry timeout
                var retryTimeout = BackoffAlgorithmBase.GetRetryTimeout(attempt, this, cancellationToken);

                Thread.Sleep(retryTimeout);

                attempt++;
            }
        }
    }
}
