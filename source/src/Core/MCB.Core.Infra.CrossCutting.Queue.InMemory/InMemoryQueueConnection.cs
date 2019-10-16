using MCB.Core.Infra.CrossCutting.Queue.InMemory.Interfaces;
using System;

namespace MCB.Core.Infra.CrossCutting.Queue.InMemory
{
    public class InMemoryQueueConnection
        : IInMemoryQueueConnection
    {
        public string Hostname { get; set; }

        public int Port { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}


