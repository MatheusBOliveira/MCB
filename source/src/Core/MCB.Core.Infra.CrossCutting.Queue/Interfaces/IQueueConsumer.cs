using MCB.Core.Infra.CrossCutting.Queue.Delegates;
using System;

namespace MCB.Core.Infra.CrossCutting.Queue.Interfaces
{
    public interface IQueueConsumer
        : IDisposable
    {
        IQueueConnection Connection { get; }
        IQueue Queue { get; }
        string Identifier { get; set; }
        ProcessReceivedMessageHandle Handle { get; }

        void CreateConnection();
        void CreateQueue();
        void SetHandle(ProcessReceivedMessageHandle handle);

        void Start(ProcessReceivedMessageHandle newHandle = null);
        void Stop();
    }
}


