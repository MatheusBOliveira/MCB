using MCB.Core.Domain.ValueObjects.Base;

namespace MCB.Core.Domain.ValueObjects
{
    public class EmailValueObject
        : ValueObjectBase
    {
        public string EmailAddress { get; set; }

        public override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}

