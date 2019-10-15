using MCB.Core.Infra.CrossCutting.Queue.InMemory.Interfaces;
using MCB.Core.Infra.CrossCutting.Queue.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Queue.InMemory
{
    class PublishedMessage
    {
        public Guid MessageId { get; set; }
        public string Message { get; set; }
    }
    class DeliveredMessage
    {
        public Guid MessageId { get; set; }
        public string ConsumerIdentifier { get; set; }
    }

    public class InMemoryQueueManager
    {
        private readonly Dictionary<string, List<PublishedMessage>> _publishedMessages;
        private readonly Dictionary<string, List<DeliveredMessage>> _deliveredMessages;
        private readonly Dictionary<string, Task> _queueWorkers;

        private readonly List<IInMemoryQueueConsumer> _consumers;

        public InMemoryQueueManager()
        {
            _publishedMessages = new Dictionary<string, List<PublishedMessage>>();
            _deliveredMessages = new Dictionary<string, List<DeliveredMessage>>();
            _queueWorkers = new Dictionary<string, Task>();

            _consumers = new List<IInMemoryQueueConsumer>();
        }

        private List<PublishedMessage> GetPublishedMessages(IQueue queue)
        {
            if (!_publishedMessages.ContainsKey(queue.Name))
                _publishedMessages.Add(queue.Name, new List<PublishedMessage>());

            return _publishedMessages[queue.Name];
        }
        private bool HasPublishedMessages(IQueue queue)
        {
            return GetPublishedMessages(queue).Any();
        }
        private PublishedMessage GetNextPublishedMessage(IQueue queue)
        {
            if (!HasPublishedMessages(queue))
                return default;

            return GetPublishedMessages(queue).FirstOrDefault();
        }

        private void CreateQueueWorker(IQueue queue)
        {
            if (_queueWorkers.ContainsKey(queue.Name))
                return;

            _queueWorkers.Add(queue.Name, Task.Run(async () => {

                while (true)
                {
                    var publishedMessage = GetNextPublishedMessage(queue);

                    if (publishedMessage == null)
                        continue;

                    var consumersToDelivery = GetNotDeliveredConsumers(queue.Name, publishedMessage.MessageId);

                    foreach (var consumer in consumersToDelivery)
                    {
                        var result = await consumer.Handle.Invoke(
                            queue,
                            consumer,
                            publishedMessage.Message);

                        InitializeDeliveryMessage(queue.Name);

                        _deliveredMessages[queue.Name]
                            .Add(new DeliveredMessage() {
                                MessageId = publishedMessage.MessageId,
                                ConsumerIdentifier = publishedMessage.Message
                            });

                        if (result.Redelivery)
                        {
                            // Redelivery
                            var messageList = _publishedMessages[queue.Name];
                            messageList.Add(new PublishedMessage()
                            {
                                MessageId = publishedMessage.MessageId,
                                Message = publishedMessage.Message
                            });
                        }
                    }

                    _publishedMessages[queue.Name].Remove(publishedMessage);
                }

            }));
        }

        private void InitializeDeliveryMessage(string queueName)
        {
            if (!_deliveredMessages.ContainsKey(queueName))
                _deliveredMessages.Add(queueName,
                    new List<DeliveredMessage>());
        }

        public void RegisterConsumer(IInMemoryQueueConsumer consumer)
        {
            _consumers.Add(consumer);

            CreateQueueWorker(consumer.Queue);
        }
        public void RemoveConsumer(IInMemoryQueueConsumer consumer)
        {
            _consumers.Remove(consumer);
        }
        public IEnumerable<IInMemoryQueueConsumer> GetConsumers()
        {
            return _consumers.AsEnumerable();
        }
        public IEnumerable<IInMemoryQueueConsumer> GetNotDeliveredConsumers(string queueName, Guid messageId)
        {
            InitializeDeliveryMessage(queueName);

            var consumersIdentifiersDelivered = _deliveredMessages[queueName].Where(q =>
                q.MessageId == messageId)
                .Select(q => q.ConsumerIdentifier);

            var consumersToReturn = 
                GetConsumers().Where(q => 
                    q.Queue.Name.Equals(queueName)
                    && !consumersIdentifiersDelivered.Contains(q.Identifier));

            return consumersToReturn;
        }

        public void SendMessage(string queueName, string message)
        {
            if (!_publishedMessages.ContainsKey(queueName))
                _publishedMessages.Add(queueName, new List<PublishedMessage>());

            _publishedMessages[queueName].Add(new PublishedMessage()
            {
                MessageId = Guid.NewGuid(),
                Message = message
            });
        }
    }
}


