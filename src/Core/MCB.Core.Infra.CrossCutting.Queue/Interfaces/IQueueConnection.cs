using System;

namespace MCB.Core.Infra.CrossCutting.Queue.Interfaces
{
    public interface IQueueConnection
        : IDisposable
    {
        string Hostname { get; set; }
        int Port { get; set; }
        string Username { get; set; }
        string Password { get; set; }
    }
}


