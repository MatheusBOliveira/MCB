namespace MCB.Core.Infra.CrossCutting.Patterns.Specification.Interfaces
{
    public interface ISelfValidator
    {
        ValidationResult ValidationResult
        {
            get;
        }

        bool IsValid();
        void Validate();
    }
}


