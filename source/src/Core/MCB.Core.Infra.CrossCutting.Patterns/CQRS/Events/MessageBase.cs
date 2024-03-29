using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events.Interfaces;
using System;
using System.Globalization;

namespace MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events
{
    public abstract class MessageBase 
        : IMessage
    {
        public Guid MessageId => Guid.NewGuid();
        public Guid AggregateId { get; set; }
        public DateTime TimeStamp => DateTime.UtcNow;
        public string MessageType => GetType().FullName;
        public CultureInfo CultureInfo { get; set; }
        public string Username { get; set; }
    }
}


