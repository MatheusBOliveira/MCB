﻿using MCB.Core.Infra.CrossCutting.Patterns.Retry.BackoffAlgorithm.Base;
using MCB.Core.Infra.CrossCutting.Patterns.Retry.BackoffAlgorithm.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MCB.Core.Infra.CrossCutting.Patterns.Retry.BackoffAlgorithm
{
    public class FullJitterBackoffAlgorithm
        : BackoffAlgorithmBase
    {
        public FullJitterBackoffAlgorithm()
            : base(BackoffAlgorithmTypeEnum.FullJitter)
        {

        }

        public override int GetRetryTimeout(int attempt, RetryPolicy retryPolicy, CancellationToken cancellationToken)
        {
            return new Random().Next(0, (int)Math.Ceiling((double)(retryPolicy.MillisecondsTimeout * 2 ^ attempt)));
        }
    }
}
