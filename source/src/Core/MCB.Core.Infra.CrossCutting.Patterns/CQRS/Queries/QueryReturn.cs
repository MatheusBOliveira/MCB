namespace MCB.Core.Infra.CrossCutting.Patterns.CQRS.Queries
{
    public class QueryReturn<TReturn>
        : MessageReturn
    {
        public TReturn ReturnObject { get; set; }

        public QueryReturn()
        {
            ReturnObject = default;
        }

        public QueryReturn(TReturn returnObject)
        {
            ReturnObject = returnObject;
        }

        public QueryReturn(bool success, bool @continue)
            : base(success, @continue)
        {

        }

        public QueryReturn(bool success, bool @continue, TReturn returnObject) 
            : base(success, @continue)
        {
            ReturnObject = returnObject;
        }
    }
}


