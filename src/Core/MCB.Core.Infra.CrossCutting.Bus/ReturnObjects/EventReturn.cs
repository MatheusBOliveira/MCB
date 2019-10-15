namespace MCB.Core.Infra.CrossCutting.Bus.ReturnObjects
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


