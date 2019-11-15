namespace MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events.Interfaces
{
    public interface IHandler<in TMessage>
        where TMessage : IMessage
    {
        void Handle(TMessage message);
    }
}


