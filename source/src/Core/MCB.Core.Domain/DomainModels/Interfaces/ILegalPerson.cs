using MCB.Core.Domain.DomainModels.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Core.Domain.DomainModels.Interfaces
{
    public interface ILegalPerson
        : IPerson,
        IActivableDomainModel
    {
    }
}
