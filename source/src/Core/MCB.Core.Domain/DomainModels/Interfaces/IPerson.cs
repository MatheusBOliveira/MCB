using MCB.Core.Domain.DomainModels.Enums;
using MCB.Core.Domain.DomainModels.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Core.Domain.DomainModels.Interfaces
{
    public interface IPerson
        : IDomainModel
    {
        PersonTypeEnum PersonType { get; set; }
        string GovernamentalDocumentNumber { get; set; }
    }
}
