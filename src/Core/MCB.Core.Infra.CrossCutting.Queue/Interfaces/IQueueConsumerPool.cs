using MCB.Core.Infra.CrossCutting.Queue.Delegates;
using System;
using System.Collections.Generic;

namespace MCB.Core.Infra.CrossCutting.Queue.Interfaces
{
    public interface IQueueConsumerPool
        : IDisposable
    {
        void AddConsumer(IQueueConsumer consumer);
        void RemoveConsumer(string identifier);

        void StartConsumer(string identifier, ProcessReceivedMessageHandle handle = null);
        void StopConsumer(string identifier);

        void StartAllConsumers(ProcessReceivedMessageHandle handle = null);
        void StopAllConsumers();
        void RemoveAllConsumers();
        void DisposeAllConsumers();

        IQueueConsumer GetConsumer(string identifier);
        IEnumerable<IQueueConsumer> GetAllConsumers();
        IEnumerable<string> GetAllConsumersIdentifiers();
    }
}


