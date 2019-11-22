using System;
using System.Collections.Generic;
using System.Text;

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
        private readonly TimeSpan _timeout;
        private readonly int _maxAttempts;

        public TimeSpan Timeout
        {
            get
            {
                return _timeout;
            }
        }
        public int MaxAttempts
        {
            get
            {
                return _maxAttempts;
            }
        }

        public RetryPolicy()
        {

        }
    }
}
