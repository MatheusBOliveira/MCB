using MCB.Core.Infra.CrossCutting.Queue.Delegates;
using MCB.Core.Infra.CrossCutting.Queue.Interfaces;
using MCB.Core.Infra.CrossCutting.Queue.RabbitMQ.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using IConnection = RabbitMQ.Client.IConnection;

namespace MCB.Core.Infra.CrossCutting.Queue.RabbitMQ
{
    public class RabbitMQConsumer
        : IRabbitMQConsumer
    {
        private IConnection _rabbitMQClientConnection;
        private IModel _rabbitMQClientChannel;
        private AsyncEventingBasicConsumer _asyncEventingBasicConsumer;

        private ProcessReceivedMessageHandle _handle;

        private IRabbitMQConnection RabbitMQConnection => (IRabbitMQConnection)Connection;
        private IRabbitMQQueue RabbitMQQueue => (IRabbitMQQueue)Queue;

        public IQueueConnection Connection { get; private set; }
        public IQueue Queue { get; private set; }
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

        public RabbitMQConsumer(
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

            _asyncEventingBasicConsumer = new AsyncEventingBasicConsumer(_rabbitMQClientChannel);

            _asyncEventingBasicConsumer.Received += async (model, ea) =>
            {
                try
                {
                    var processReturn = await Handle.Invoke(Queue, this, Encoding.UTF8.GetString(ea.Body));

                    if (processReturn.Success)
                        _rabbitMQClientChannel.BasicAck(ea.DeliveryTag, processReturn.Redelivery);
                    else
                        _rabbitMQClientChannel.BasicNack(ea.DeliveryTag, false, processReturn.Redelivery);
                }
                catch (Exception)
                {
                    throw;
                }
            };
        }
        public void SetHandle(ProcessReceivedMessageHandle handle)
        {
            Handle = handle;
        }

        public void Start(ProcessReceivedMessageHandle newHandle = null)
        {
            if(newHandle != null)
                SetHandle(newHandle);

            CreateConnection();
            CreateQueue();

            _rabbitMQClientChannel.BasicConsume(
                queue: RabbitMQQueue.Name,
                autoAck: RabbitMQQueue.AutoAck,
                consumer: _asyncEventingBasicConsumer);
        }
        public void Stop()
        {
            _rabbitMQClientChannel?.Dispose();
            _rabbitMQClientConnection?.Dispose();
        }

        public void Dispose()
        {
            Stop();
            GC.SuppressFinalize(this);
        }
    }
}


