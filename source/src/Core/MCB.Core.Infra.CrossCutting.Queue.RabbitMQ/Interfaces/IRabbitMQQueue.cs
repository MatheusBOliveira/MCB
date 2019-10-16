using MCB.Core.Infra.CrossCutting.Queue.Interfaces;
using System.Collections.Generic;

namespace MCB.Core.Infra.CrossCutting.Queue.RabbitMQ.Interfaces
{
    public interface IRabbitMQQueue
        : IQueue
    {
        bool Durable { get; set; }
        bool Exclusive { get; set; }
        bool AutoDelete { get; set; }
        Dictionary<string, object> Arguments { get; set; }
        bool AutoAck { get; set; }
        bool IsExchange { get; set; }
        string ExchangeName { get; set; }
    }
}


