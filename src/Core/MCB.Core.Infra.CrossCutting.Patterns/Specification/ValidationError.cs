namespace MCB.Core.Infra.CrossCutting.Patterns.Specification
{
    public class ValidationError
    {
        public string Code
        {
            get;
            set;
        }

        public ValidationError(string code)
        {
            Code = code;
        }
    }
}


