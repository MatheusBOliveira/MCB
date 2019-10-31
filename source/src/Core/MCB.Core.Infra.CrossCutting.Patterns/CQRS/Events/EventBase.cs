using MCB.Core.Infra.CrossCutting.Patterns.Specification;
using System.Linq;

namespace MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events
{
    public abstract class EventBase 
        : MessageBase
    {
        public ValidationResult ValidationResult { get; set; }

        public EventBase()
        {
            ValidationResult = new ValidationResult();
        }

        protected void AddValidationResult(ValidationResult validationResult)
        {
            foreach (var error in validationResult.ValidationMessageErrors)
                ValidationResult.Add(error);
        }
    }
}


