using MCB.Core.Infra.CrossCutting.Patterns.Retry.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MCB.Core.Infra.CrossCutting.Patterns.Retry.Base
{
    public abstract class BackoffAlgorithmBase
    {
        private readonly BackoffAlgorithmTypeEnum _backoffAlgorithmType;

        public BackoffAlgorithmTypeEnum BackoffAlgorithmType
        {
            get
            {
                return _backoffAlgorithmType;
            }
        }

        protected BackoffAlgorithmBase(BackoffAlgorithmTypeEnum backoffAlgorithmType)
        {
            _backoffAlgorithmType = backoffAlgorithmType;
        }

        public abstract int GetRetryTimeout(int attempt, RetryPolicy retryPolicy, CancellationToken cancellationToken);
    }
}
