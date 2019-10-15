using MCB.Core.Infra.CrossCutting.ExtensionMethods;
using MCB.Core.Infra.CrossCutting.Queue.InMemory.Interfaces;
using MCB.Core.Infra.CrossCutting.Queue.Interfaces;
using System;

namespace MCB.Core.Infra.CrossCutting.Queue.InMemory
{
    public class InMemoryQueuePublisher
        : IInMemoryQueuePublisher
    {
        private readonly InMemoryQueueManager _inMemoryQueueManager;

        private IInMemoryQueueConnection InMemoryConnection => (IInMemoryQueueConnection)Connection;
        private IInMemoryQueue InMemoryQueue => (IInMemoryQueue)Queue;

        public IQueueConnection Connection { get; set; }
        public IQueue Queue { get; set; }

        public InMemoryQueuePublisher(
            InMemoryQueueManager inMemoryQueueManager,
            IInMemoryQueueConnection connection,
            IInMemoryQueue queue)
        {
            _inMemoryQueueManager = inMemoryQueueManager;

            Connection = connection;
            Queue = queue;
        }

        public void CreateConnection()
        {
            throw new NotImplementedException();
        }
        public void CreateQueue()
        {
            throw new NotImplementedException();
        }

        public void PublishMessage(string message)
        {
            _inMemoryQueueManager.SendMessage(Queue.Name, message);
        }
        public void PublishMessage<T>(T obj)
        {
            PublishMessage(obj.SerializeToJson());
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}


