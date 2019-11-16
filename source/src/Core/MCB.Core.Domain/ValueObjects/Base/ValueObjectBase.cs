using MCB.Core.Infra.CrossCutting.Patterns.Specification;
using MCB.Core.Infra.CrossCutting.Patterns.Specification.Interfaces;
using System;

namespace MCB.Core.Domain.ValueObjects.Base
{
    public abstract class ValueObjectBase
        : IDisposable
    {
        public ValidationResult ValidationResult { get; set; }

        public virtual bool IsValid()
        {
            return ValidationResult?.IsValid == true;
        }

        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

