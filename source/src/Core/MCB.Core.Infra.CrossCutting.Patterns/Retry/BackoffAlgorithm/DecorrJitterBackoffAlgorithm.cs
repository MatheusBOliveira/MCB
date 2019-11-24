using MCB.Core.Infra.CrossCutting.Patterns.Retry.BackoffAlgorithm.Base;
using MCB.Core.Infra.CrossCutting.Patterns.Retry.BackoffAlgorithm.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MCB.Core.Infra.CrossCutting.Patterns.Retry.BackoffAlgorithm
{
    public class DecorrJitterBackoffAlgorithm
        : BackoffAlgorithmBase
    {
        public DecorrJitterBackoffAlgorithm() 
            : base(BackoffAlgorithmTypeEnum.Decorr)
        {

        }

        public override int GetRetryTimeout(int attempt, RetryPolicy retryPolicy, CancellationToken cancellationToken)
        {
            var temp = retryPolicy.MillisecondsTimeout * 2 ^ attempt;
            var sleep = temp / 2 + new Random().Next(0, temp / 2);
            return new Random().Next(retryPolicy.MillisecondsTimeout, sleep * 3);
            //return new Random().Next(retryPolicy.Timeout, sleep / 3);
        }
    }
}
