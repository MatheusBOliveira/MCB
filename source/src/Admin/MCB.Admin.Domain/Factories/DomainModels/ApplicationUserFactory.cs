using MCB.Admin.Domain.DomainModels;
using MCB.Admin.Domain.Factories.DomainModels.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.Factory;
using MCB.Core.Infra.CrossCutting.Patterns.Factory.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MCB.Admin.Domain.Factories.DomainModels
{
    public class ApplicationUserFactory
        : FactoryBase<ApplicationUser>,
        IApplicationUserFactory
    {
        public override ApplicationUser Create(CultureInfo culture)
        {
            return new ApplicationUser();
        }

        public ApplicationUser Create((User user, Application application) parameter, CultureInfo culture)
        {
            var applicationUser = Create(culture);

            applicationUser.Application = parameter.application;
            applicationUser.User = parameter.user;

            return applicationUser;
        }
    }
}
