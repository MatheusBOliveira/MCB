using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using MCB.Core.Infra.CrossCutting.Patterns.Specification;
using System;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events
{
    public abstract class CommandBase
        : MessageBase
    {
        public DateTime Timestamp { get; set; }
        public ValidationResult ValidationResult { get; set; }

        protected CommandBase()
        {
            Timestamp = DateTime.Now;
        }

        public abstract Task<bool> IsValid();
    }
}


