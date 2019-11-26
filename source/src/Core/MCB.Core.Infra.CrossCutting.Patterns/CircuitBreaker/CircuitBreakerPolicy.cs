using MCB.Core.Infra.CrossCutting.Patterns.CircuitBreaker.Enums;
using MCB.Core.Infra.CrossCutting.Patterns.Retry;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Patterns.CircuitBreaker
{
    public class CircuitBreakerPolicy
    {
        private readonly RetryPolicy _retryPolicy;
        private readonly int _millisecondsSleepWindowTimeout;
        private CircuitStateEnum _circuitState;

        public RetryPolicy RetryPolicy
        {
            get
            {
                return _retryPolicy;
            }
        }
        public int MillisecondsSleepWindowTimeout
        {
            get
            {
                return _millisecondsSleepWindowTimeout;
            }
        }
        public CircuitStateEnum CircuitState
        {
            get
            {
                return _circuitState;
            }

            protected set
            {
                _circuitState = value;
            }
        }

        public delegate void CircuitOpenedHandler(CircuitBreakerPolicy circuitBreakerPolicy);
        public delegate void CircuitHalfOpenedHandler(CircuitBreakerPolicy circuitBreakerPolicy);
        public delegate void CircuitClosedHandler(CircuitBreakerPolicy circuitBreakerPolicy);

        public event CircuitOpenedHandler CircuitOpenedEvent;
        public event CircuitHalfOpenedHandler CircuitHalfOpenedEvent;
        public event CircuitClosedHandler CircuitClosedEvent;

        public CircuitBreakerPolicy(RetryPolicy retryPolicy, int millisecondsSleepWindowTimeout)
        {
            _retryPolicy = retryPolicy;
            _millisecondsSleepWindowTimeout = millisecondsSleepWindowTimeout;

            CircuitState = CircuitStateEnum.Closed;
        }

        private void CloseCircuit()
        {
            CircuitState = CircuitStateEnum.Closed;
            CircuitClosedEvent?.Invoke(this);
        }

        private void HalfOpenCircuit()
        {
            CircuitState = CircuitStateEnum.HalfOpen;
            CircuitHalfOpenedEvent?.Invoke(this);
        }
        private void OpenCircuit()
        {
            CircuitState = CircuitStateEnum.Open;
            CircuitOpenedEvent?.Invoke(this);
        }

        public async Task<bool> Execute(CancellationToken cancellationToken = default)
        {
            if (CircuitState == CircuitStateEnum.Open)
                return await Task.FromResult(false);

            // If CircuitState if Closed or HalfOpen

            var executionReturn = await RetryPolicy.Execute(cancellationToken);

            if (executionReturn)
            {
                CloseCircuit();
                return await Task.FromResult(true);
            }

            OpenCircuit();
            _ = Task.Run(() =>
            {
                Thread.Sleep(MillisecondsSleepWindowTimeout);
                HalfOpenCircuit();
            });

            return await Task.FromResult(false);

        }

    }
}
