using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using MCB.Core.Infra.CrossCutting.Patterns.Specification;
using System;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events
{
    public abstract class CommandBase
        : MessageBase
    {
        public ValidationResult ValidationResult { get; set; }

        public virtual bool IsValid()
        {
            return ValidationResult.IsValid;
        }
    }
}


