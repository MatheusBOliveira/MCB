using MCB.Core.Infra.CrossCutting.Queue.Delegates;
using MCB.Core.Infra.CrossCutting.Queue.InMemory.Interfaces;
using MCB.Core.Infra.CrossCutting.Queue.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MCB.Core.Infra.CrossCutting.Queue.InMemory
{
    public class InMemoryQueueConsumerPool
        : IInMemoryQueueConsumerPool
    {
        private readonly List<IQueueConsumer> _consumerCollection;

        public InMemoryQueueConsumerPool()
        {
            _consumerCollection = new List<IQueueConsumer>();
        }

        public void AddConsumer(IQueueConsumer consumer)
        {
            if (GetConsumer(consumer.Identifier) != null)
                throw new ArgumentException("Identifier has been added");

            _consumerCollection.Add(consumer);
        }
        public void RemoveConsumer(string identifier)
        {
            var consumer = GetConsumer(identifier);

            if (consumer != null)
                _consumerCollection.Remove(consumer);
        }
        public void StartConsumer(string identifier, ProcessReceivedMessageHandle handle = null)
        {
            var consumer = GetConsumer(identifier);

            if (consumer == null)
                throw new ArgumentException("Consumer not found");

            consumer.Start(handle ?? consumer.Handle);
        }
        public void StopConsumer(string identifier)
        {
            var consumer = GetConsumer(identifier);

            if (consumer == null)
                throw new ArgumentException("Consumer not found");

            consumer.Stop();
        }

        public IQueueConsumer GetConsumer(string identifier)
        {
            return _consumerCollection.FirstOrDefault(q => q.Identifier.Equals(identifier));
        }
        public IEnumerable<IQueueConsumer> GetAllConsumers()
        {
            return _consumerCollection.AsEnumerable();
        }
        public IEnumerable<string> GetAllConsumersIdentifiers()
        {
            return _consumerCollection.Select(q => q.Identifier);
        }
        public void StartAllConsumers(ProcessReceivedMessageHandle handle = null)
        {
            for (int i = 0; i < _consumerCollection.Count; i++)
                _consumerCollection[i].Start(handle);
        }
        public void RemoveAllConsumers()
        {
            while (_consumerCollection.Count > 0)
                RemoveConsumer(_consumerCollection[0].Identifier);
        }
        public void StopAllConsumers()
        {
            for (int i = 0; i < _consumerCollection.Count; i++)
                _consumerCollection[i].Stop();
        }
        public void DisposeAllConsumers()
        {
            StopAllConsumers();

            for (int i = 0; i < _consumerCollection.Count; i++)
                _consumerCollection[i].Dispose();
        }

        public void Dispose()
        {
            foreach (var consumer in _consumerCollection)
                consumer.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}


