using System;

namespace MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events
{
    public abstract class MessageBase
    {
        public Guid MessageId => Guid.NewGuid();
        public Guid AggregateId { get; set; }
        public DateTime TimeStamp => DateTime.UtcNow;
        public string MessageType => GetType().FullName;
        public Guid ApplicationId { get; set; }
        public string Username { get; set; }
    }
}


