using System;

namespace MCB.Core.Infra.CrossCutting.Patterns.Adapter.Interfaces
{
    public interface IAdapter<TTarget, TSource>
        : IDisposable
    {
        TTarget Adapt(TTarget target, TSource source);
    }
}


