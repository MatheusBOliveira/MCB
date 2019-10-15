using MCB.Core.Infra.CrossCutting.Queue.InMemory.Interfaces;
using System;

namespace MCB.Core.Infra.CrossCutting.Queue.InMemory
{
    public class InMemoryQueue
        : IInMemoryQueue
    {
        public string Name { get; set; }

        public InMemoryQueue()
        {
            Name = "InMemoryQueue";
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}


