using MCB.Admin.Domain.DomainModels;
using MCB.Core.Infra.CrossCutting.Patterns.Factory.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Admin.Domain.Factories.DomainModels.Interfaces
{
    public interface IApplicationRoleFactory
        : IFactory<ApplicationRole>
    {
    }
}
