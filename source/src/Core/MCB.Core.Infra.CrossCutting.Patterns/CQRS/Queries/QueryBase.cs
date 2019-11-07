using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Queries.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.Specification;
using System;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Patterns.CQRS.Queries
{
    public abstract class QueryBase
        : MessageBase,
        IQuery
    {
        public ValidationResult ValidationResult { get; set; }

        public bool IsValid()
        {
            return ValidationResult?.IsValid == true;
        }
        public abstract void Validate();

        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}


