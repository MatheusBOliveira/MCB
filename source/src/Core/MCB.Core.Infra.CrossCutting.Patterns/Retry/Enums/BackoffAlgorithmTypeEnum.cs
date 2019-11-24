using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Core.Infra.CrossCutting.Patterns.Retry.Enums
{
    public enum BackoffAlgorithmTypeEnum
    {
        Decorr = 1,
        EqualJitter = 2,
        FullJitter = 3
    }
}
