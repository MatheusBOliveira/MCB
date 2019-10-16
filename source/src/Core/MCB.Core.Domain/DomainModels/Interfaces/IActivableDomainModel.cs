using MCB.Core.Domain.ValueObjects;

namespace MCB.Core.Domain.DomainModels.Interfaces
{
    public interface IActivableDomainModel
        : IDomainModel
    {
        ActivableInfoValueObject ActivableInfo { get; set; }
    }
}

