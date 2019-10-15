namespace MCB.Core.Infra.CrossCutting.Bus.ReturnObjects
{
    public class CommandReturn<TReturn>
        : MessageReturn
    {
        public TReturn ReturnObject { get; set; }

        public CommandReturn()
        {
        }

        public CommandReturn(bool success, bool @continue) 
            : base(success, @continue)
        {
        }
    }
}


