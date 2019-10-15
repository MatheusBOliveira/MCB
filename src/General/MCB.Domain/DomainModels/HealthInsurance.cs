using MCB.Core.Domain.DomainModels.Interfaces;
using MCB.Core.Domain.ValueObjects;
using System;

namespace MCB.Domain.DomainModels
{
    public class HealthInsurance
        : IDomainModel,
          IAuditableDomainModel
    {
        public string Name { get; set; } 

        public AuditableInfoValueObject AuditableInfo { get; set; }
        public DomainModelValueObject DomainModel { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

