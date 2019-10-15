using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using MCB.Core.Infra.CrossCutting.Patterns.Tests.DomainModels;

namespace MCB.Core.Infra.CrossCutting.Patterns.Tests.Events
{
    public class CustomerRegisteredEvent
        : EventBase
    {
        public Customer Customer { get; set; }
        public User User { get; set; }
    }
}


