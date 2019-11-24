using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Core.Infra.CrossCutting.Patterns.Retry.BackoffAlgorithm.Enums
{
    public enum BackoffAlgorithmTypeEnum
    {
        None = 0,
        Decorr = 1,
        EqualJitter = 2,
        FullJitter = 3,
        Progressive = 4
    }
}
