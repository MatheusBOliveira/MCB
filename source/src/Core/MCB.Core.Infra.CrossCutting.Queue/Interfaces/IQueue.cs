using System;

namespace MCB.Core.Infra.CrossCutting.Queue.Interfaces
{
    public interface IQueue
        : IDisposable
    {
        string Name { get; set; }
    }
}


