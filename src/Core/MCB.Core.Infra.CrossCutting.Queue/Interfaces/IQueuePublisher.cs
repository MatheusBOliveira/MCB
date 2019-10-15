using System;

namespace MCB.Core.Infra.CrossCutting.Queue.Interfaces
{
    public interface IQueuePublisher
        : IDisposable
    {
        IQueueConnection Connection { get; }
        IQueue Queue { get; }

        void CreateConnection();
        void CreateQueue();

        void PublishMessage(string message);
        void PublishMessage<T>(T obj);
    }
}


