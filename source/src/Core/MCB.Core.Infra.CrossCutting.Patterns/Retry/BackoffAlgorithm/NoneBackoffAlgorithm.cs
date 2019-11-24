using MCB.Core.Infra.CrossCutting.Patterns.Retry.BackoffAlgorithm.Base;
using MCB.Core.Infra.CrossCutting.Patterns.Retry.BackoffAlgorithm.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MCB.Core.Infra.CrossCutting.Patterns.Retry.BackoffAlgorithm
{
    public class NoneBackoffAlgorithm
        : BackoffAlgorithmBase
    {
        public NoneBackoffAlgorithm() 
            : base(BackoffAlgorithmTypeEnum.None)
        {
        }

        public override int GetRetryTimeout(int attempt, RetryPolicy retryPolicy, CancellationToken cancellationToken)
        {
            return retryPolicy.MillisecondsTimeout;
        }
    }
}
