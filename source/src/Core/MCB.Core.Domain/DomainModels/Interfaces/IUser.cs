using MCB.Core.Domain.DomainModels.Interfaces.Base;
using MCB.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Core.Domain.DomainModels.Interfaces
{
    public interface IUser
        : IAuditableDomainModel,
        IActivableDomainModel
    {
        Guid CustomerId { get; set; }
        EmailValueObject Email { get; set; }
    }
}
