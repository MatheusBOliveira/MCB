using MCB.Core.Domain.ValueObjects.Base;
using System;

namespace MCB.Core.Domain.ValueObjects
{
    public class AuditableInfoValueObject
        : ValueObjectBase
    {
        public string CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedUser { get; set; }
        public DateTime UpdatedDate { get; set; }
        public byte[] RegistryVersion { get; set; }

        public void SetNewRegistryVersion()
        {
            RegistryVersion = BitConverter.GetBytes(DateTime.UtcNow.Ticks);
        }

        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}

