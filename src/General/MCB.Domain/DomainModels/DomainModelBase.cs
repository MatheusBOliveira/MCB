using MCB.Core.Domain.DomainModels.Interfaces;
using MCB.Core.Domain.ValueObjects;
using System;

namespace MCB.Domain.DomainModels
{
    public abstract class DomainModelBase
        : IDomainModel,
          IAuditableDomainModel
    {
        public DomainModelValueObject DomainModel { get; set; }
        public AuditableInfoValueObject AuditableInfo { get; set; }

        public DomainModelBase()
        {
            DomainModel = new DomainModelValueObject();
            AuditableInfo = new AuditableInfoValueObject();
        }

        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

