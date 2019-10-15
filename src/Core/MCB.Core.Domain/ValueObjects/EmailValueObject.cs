using MCB.Core.Domain.ValueObjects.Base;

namespace MCB.Core.Domain.ValueObjects
{
    public class EmailValueObject
        : ValueObjectBase
    {
        public string EmailAddress { get; set; }
    }
}

