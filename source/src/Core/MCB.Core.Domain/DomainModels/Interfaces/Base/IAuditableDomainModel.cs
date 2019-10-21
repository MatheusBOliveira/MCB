using MCB.Core.Domain.ValueObjects;

namespace MCB.Core.Domain.DomainModels.Interfaces.Base
{
    public interface IAuditableDomainModel
        : IDomainModel
    {
        AuditableInfoValueObject AuditableInfo { get; set; }
    }
}

