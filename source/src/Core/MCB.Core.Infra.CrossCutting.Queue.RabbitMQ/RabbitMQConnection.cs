using MCB.Core.Infra.CrossCutting.Queue.RabbitMQ.Interfaces;
using System;

namespace MCB.Core.Infra.CrossCutting.Queue.RabbitMQ
{
    public class RabbitMQConnection
        : IRabbitMQConnection
    {
        public string Hostname { get; set; }

        public int Port { get; set; }
        public string VirtualHost { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}


