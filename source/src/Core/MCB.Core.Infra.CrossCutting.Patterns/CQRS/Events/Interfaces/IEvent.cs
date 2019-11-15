using MCB.Core.Infra.CrossCutting.Patterns.Specification;

namespace MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events.Interfaces
{
    public interface IEvent
        : IMessage
    {
        ValidationResult ValidationResult { get; set; }
    }
}