using MCB.Core.Infra.CrossCutting.Patterns.Retry.BackoffAlgorithm.Base;
using MCB.Core.Infra.CrossCutting.Patterns.Retry.BackoffAlgorithm.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MCB.Core.Infra.CrossCutting.Patterns.Retry.BackoffAlgorithm
{
    public class EqualJitterBackoffAlgorithm
        : BackoffAlgorithmBase
    {
        public EqualJitterBackoffAlgorithm()
            : base(BackoffAlgorithmTypeEnum.EqualJitter)
        {

        }

        public override int GetRetryTimeout(int attempt, RetryPolicy retryPolicy, CancellationToken cancellationToken)
        {
            var temp = retryPolicy.MillisecondsTimeout * 2 ^ attempt;
            return temp / 2 + new Random().Next(0, temp / 2);
        }
    }
}
