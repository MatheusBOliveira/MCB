namespace MCB.Core.Infra.CrossCutting.Bus.ReturnObjects
{
    public class QueryReturn<TReturn>
        : MessageReturn
    {
        public TReturn ReturnObject { get; set; }

        public QueryReturn()
        {
            ReturnObject = default;
        }

        public QueryReturn(bool success, bool @continue, TReturn returnObject) 
            : base(success, @continue)
        {
            ReturnObject = returnObject;
        }
    }
}


