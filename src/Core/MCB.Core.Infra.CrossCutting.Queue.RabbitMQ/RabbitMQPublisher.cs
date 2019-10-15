using MCB.Core.Infra.CrossCutting.ExtensionMethods;
using MCB.Core.Infra.CrossCutting.Queue.Interfaces;
using MCB.Core.Infra.CrossCutting.Queue.RabbitMQ.Interfaces;
using RabbitMQ.Client;
using System;
using System.Text;
using IConnection = RabbitMQ.Client.IConnection;

namespace MCB.Core.Infra.CrossCutting.Queue.RabbitMQ
{
    public class RabbitMQPublisher
        : IRabbitMQPublisher
    {
        private IConnection _rabbitMQClientConnection;
        private IModel _rabbitMQClientChannel;

        private IRabbitMQConnection RabbitMQConnection => (IRabbitMQConnection)Connection;
        private IRabbitMQQueue RabbitMQQueue => (IRabbitMQQueue)Queue;

        public IQueueConnection Connection { get; private set; }
        public IQueue Queue { get; private set; }

        public RabbitMQPublisher(
            IRabbitMQConnection connection,
            IRabbitMQQueue queue)
        {
            Connection = connection;
            Queue = queue;
        }

        public void CreateConnection()
        {
            var factory = new ConnectionFactory()
            {
                HostName = RabbitMQConnection.Hostname,
                Port = RabbitMQConnection.Port,
                UserName = RabbitMQConnection.Username,
                Password = RabbitMQConnection.Password,
                DispatchConsumersAsync = true
            };

            if (!string.IsNullOrWhiteSpace(RabbitMQConnection.VirtualHost))
                factory.VirtualHost = RabbitMQConnection.VirtualHost;

            _rabbitMQClientConnection = factory.CreateConnection();
        }
        public void CreateQueue()
        {
            _rabbitMQClientChannel = _rabbitMQClientConnection.CreateModel();
            _rabbitMQClientChannel.QueueDeclare(
                queue: RabbitMQQueue.Name,
                durable: RabbitMQQueue.Durable,
                exclusive: RabbitMQQueue.Exclusive,
                autoDelete: RabbitMQQueue.AutoDelete,
                arguments: RabbitMQQueue.Arguments);
        }
        
        public void PublishMessage(string message)
        {
            if(_rabbitMQClientConnection?.IsOpen != true)
            {
                CreateConnection();
                CreateQueue();
            }

            _rabbitMQClientChannel.BasicPublish(
                exchange: !RabbitMQQueue.IsExchange ? "" : RabbitMQQueue.ExchangeName,
                routingKey: RabbitMQQueue.Name,
                basicProperties: null,
                body: Encoding.UTF8.GetBytes(message));
        }
        public void PublishMessage<T>(T obj)
        {
            PublishMessage(obj.SerializeToJson());
        }

        public void Dispose()
        {
            _rabbitMQClientChannel?.Dispose();
            _rabbitMQClientConnection?.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}


