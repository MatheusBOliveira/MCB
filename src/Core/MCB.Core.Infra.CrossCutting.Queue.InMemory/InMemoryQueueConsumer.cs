using MCB.Core.Infra.CrossCutting.Queue.Delegates;
using MCB.Core.Infra.CrossCutting.Queue.InMemory.Interfaces;
using MCB.Core.Infra.CrossCutting.Queue.Interfaces;
using System;

namespace MCB.Core.Infra.CrossCutting.Queue.InMemory
{
    public class InMemoryQueueConsumer
        : IInMemoryQueueConsumer
    {
        private bool _started;
        private ProcessReceivedMessageHandle _handle;

        private readonly InMemoryQueueManager _inMemoryQueueManager;

        private IInMemoryQueueConnection InMemoryConnection => (IInMemoryQueueConnection)Connection;
        private IInMemoryQueue InMemoryQueue => (IInMemoryQueue)Queue;

        public IQueueConnection Connection { get; set; }
        public IQueue Queue { get; set; }
        public string Identifier { get; set; }

        public ProcessReceivedMessageHandle Handle
        {
            get
            {
                return _handle;
            }
            private set
            {
                _handle = value;
            }
        }

        public InMemoryQueueConsumer(
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

        }
        public void CreateQueue()
        {

        }

        public void SetHandle(ProcessReceivedMessageHandle handle)
        {
            Handle = handle;
        }

        public void Start(ProcessReceivedMessageHandle newHandle = null)
        {
            if (_started)
                return;

            if (string.IsNullOrWhiteSpace(Identifier))
                throw new ArgumentNullException("The identifier is mandatory");

            if(newHandle != null)
                SetHandle(newHandle);

            _inMemoryQueueManager.RegisterConsumer(this);

            _started = true;
        }
        public void Stop()
        {
            if (!_started)
                return;

            _inMemoryQueueManager.RemoveConsumer(this);

            _started = false;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}


