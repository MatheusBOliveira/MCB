namespace MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events
{
    public class CommandReturn<TReturn>
        : MessageReturn
    {
        public TReturn ReturnObject { get; set; }

        public CommandReturn()
        {
        }

        public CommandReturn(TReturn returnObject)
            : this()
        {
            ReturnObject = returnObject;
        }

        public CommandReturn(bool success, bool @continue) 
            : base(success, @continue)
        {

        }
    }
}


