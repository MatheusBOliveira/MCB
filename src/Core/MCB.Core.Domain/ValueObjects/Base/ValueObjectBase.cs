using System;

namespace MCB.Core.Domain.ValueObjects.Base
{
    public abstract class ValueObjectBase
        : IDisposable
    {
        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

