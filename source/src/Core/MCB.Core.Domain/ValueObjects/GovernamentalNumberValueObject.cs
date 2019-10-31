using MCB.Core.Domain.ValueObjects.Base;
using MCB.Core.Infra.CrossCutting.Patterns.Specification;
using MCB.Core.Infra.CrossCutting.Patterns.Specification.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Core.Domain.ValueObjects
{
    public class GovernamentalNumberValueObject
        : ValueObjectBase,
        ISelfValidator
    {

        public string DocumentNumber { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public virtual bool IsValid()
        {
            return true;
        }
    }
}
