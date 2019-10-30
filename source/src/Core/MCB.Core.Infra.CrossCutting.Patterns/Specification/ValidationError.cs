namespace MCB.Core.Infra.CrossCutting.Patterns.Specification
{
    public class ValidationError
    {
        public string Code
        {
            get;
            set;
        }
        public string DefaultDescription
        {
            get;
            set;
        }

        public ValidationError(string code, string defaultDescription)
        {
            Code = code;
            DefaultDescription = defaultDescription;
        }
    }
}


