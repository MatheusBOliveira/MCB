namespace MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events.Interfaces
{
    public interface IEventStore
    {
        void Save<TEvent>(TEvent theEvent) where TEvent : EventBase;
    }
}


