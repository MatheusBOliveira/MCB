using MCB.Core.Domain.DomainModels.Enums;
using MCB.Core.Domain.DomainModels.Interfaces.Base;
using MCB.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Core.Domain.DomainModels.Interfaces
{
    public interface IPerson
        : IAuditableDomainModel
    {
        string Name { get; set; }
        PersonTypeEnum PersonType { get; set; }
        GovernamentalNumberValueObject GovernamentalDocument { get; set; }
    }
}
