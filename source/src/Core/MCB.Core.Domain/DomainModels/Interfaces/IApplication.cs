using MCB.Core.Domain.DomainModels.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Core.Domain.DomainModels.Interfaces
{
    public interface IApplication
        : IAuditableDomainModel,
        IActivableDomainModel
    {
        string Name { get; set; }
    }
}
