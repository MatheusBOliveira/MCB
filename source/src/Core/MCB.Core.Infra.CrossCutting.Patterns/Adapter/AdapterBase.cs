using System;

namespace MCB.Core.Infra.CrossCutting.Patterns.Adapter
{
    public abstract class AdapterBase
    {
        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}


