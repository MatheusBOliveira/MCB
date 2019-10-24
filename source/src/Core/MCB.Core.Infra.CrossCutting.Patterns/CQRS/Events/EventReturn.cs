namespace MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events
{
    public class EventReturn
        : MessageReturn
    {
        public EventReturn()
        {
        }

        public EventReturn(bool success, bool @continue) 
            : base(success, @continue)
        {
        }
    }
}


