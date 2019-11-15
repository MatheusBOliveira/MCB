using System;
using System.Globalization;

namespace MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events.Interfaces
{
    public interface IMessage
    {
        Guid MessageId { get; }
        string MessageType { get; }
        DateTime TimeStamp { get; }
        Guid AggregateId { get; set; }
        string Username { get; set; }
        CultureInfo CultureInfo { get; set; }
    }
}