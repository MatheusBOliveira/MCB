using MCB.Admin.Domain.DomainModels;
using MCB.Admin.Domain.Factories.DomainModels.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.Factory;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MCB.Admin.Domain.Factories.DomainModels
{
    public class ApplicationRoleFactory
        : FactoryBase<ApplicationRole>,
        IApplicationRoleFactory
    {
        public override ApplicationRole Create(CultureInfo culture)
        {
            return new ApplicationRole();
        }
    }
}
