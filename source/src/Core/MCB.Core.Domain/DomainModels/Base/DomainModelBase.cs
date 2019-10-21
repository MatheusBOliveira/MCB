using MCB.Core.Domain.DomainModels.Interfaces.Base;
using MCB.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Core.Domain.DomainModels.Base
{
    public abstract class DomainModelBase
        : IAuditableDomainModel
    {
        public DomainModelValueObject DomainModel { get; set; }
        public AuditableInfoValueObject AuditableInfo { get; set; }

        protected DomainModelBase()
        {
            DomainModel = new DomainModelValueObject();
            AuditableInfo = new AuditableInfoValueObject();
        }

        public virtual void Dispose()
        {
            DomainModel.Dispose();
            AuditableInfo.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
