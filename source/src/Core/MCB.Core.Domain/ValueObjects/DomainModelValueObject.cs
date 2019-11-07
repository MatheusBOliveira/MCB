using MCB.Core.Domain.ValueObjects.Base;
using System;

namespace MCB.Core.Domain.ValueObjects
{
    public class DomainModelValueObject
        : ValueObjectBase
    {
        public Guid Id { get; set; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as DomainModelValueObject;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo is null)
                return false;

            return Id.Equals(compareTo.Id);
        }
        public static bool operator ==(DomainModelValueObject a, DomainModelValueObject b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }
        public static bool operator !=(DomainModelValueObject a, DomainModelValueObject b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }
        public override string ToString()
        {
            return $"{GetType().Name} [Id='{Id}']";
        }

        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}

