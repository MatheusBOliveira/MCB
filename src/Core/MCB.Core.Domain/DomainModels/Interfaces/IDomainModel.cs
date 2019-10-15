using MCB.Core.Domain.ValueObjects;
using System;

namespace MCB.Core.Domain.DomainModels.Interfaces
{
    public interface IDomainModel
        : IDisposable
    {
        DomainModelValueObject DomainModel { get; set; }
    }
}

