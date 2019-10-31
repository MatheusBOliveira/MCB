using System;
using System.Globalization;

namespace MCB.Core.Infra.CrossCutting.Patterns.Factory
{
    public abstract class FactoryBase<T>
        : IDisposable
    {
        public abstract T Create(CultureInfo culture);

        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}


