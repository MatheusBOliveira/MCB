using MCB.Core.Domain.ValueObjects.Base;
using MCB.Core.Infra.CrossCutting.Patterns.Specification.Interfaces;

namespace MCB.Core.Domain.ValueObjects
{
    public class EmailValueObject
        : ValueObjectBase,
        ISelfValidator
    {
        public string EmailAddress { get; set; }

        public void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}

