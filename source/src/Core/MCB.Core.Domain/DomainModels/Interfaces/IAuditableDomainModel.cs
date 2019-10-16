using MCB.Core.Domain.ValueObjects;

namespace MCB.Core.Domain.DomainModels.Interfaces
{
    public interface IAuditableDomainModel
        : IDomainModel
    {
        AuditableInfoValueObject AuditableInfo { get; set; }
    }
}

