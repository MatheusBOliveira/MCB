using MCB.Core.Infra.CrossCutting.Queue.RabbitMQ.Interfaces;
using System;
using System.Collections.Generic;

namespace MCB.Core.Infra.CrossCutting.Queue.RabbitMQ
{
    public class RabbitMQQueue
        : IRabbitMQQueue
    {
        public string Name { get; set; }
        public bool Durable { get; set; }
        public bool Exclusive { get; set; }
        public bool AutoDelete { get; set; }
        public Dictionary<string, object> Arguments { get; set; }
        public bool AutoAck { get; set; }
        public bool IsExchange { get; set; }
        public string ExchangeName { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}


