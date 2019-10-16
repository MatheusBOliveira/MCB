using System;

namespace MCB.Core.Infra.CrossCutting.Patterns.Factory
{
    public abstract class FactoryBase<T>
        : IDisposable
    {
        public abstract T Create();

        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}


