using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Core.Infra.CrossCutting.Patterns.CircuitBreaker.Enums
{
    public enum CircuitStateEnum
    {
        Closed = 1,
        HalfOpen = 2,
        Open = 3
    }
}
