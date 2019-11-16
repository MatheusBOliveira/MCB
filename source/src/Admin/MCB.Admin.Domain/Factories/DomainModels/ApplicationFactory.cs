using MCB.Admin.Domain.Commands.Customers;
using MCB.Admin.Domain.DomainModels;
using MCB.Admin.Domain.Factories.DomainModels.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.Factory;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MCB.Admin.Domain.Factories.DomainModels
{
    public class ApplicationFactory
        : FactoryBase<Application>,
        IApplicationFactory
    {
        public override Application Create(CultureInfo culture)
        {
            return new Application();
        }

        public Application Create(RegisterNewCustomerCommand parameter, CultureInfo culture)
        {
            var application = Create(culture);

            application.Name = parameter.ApplicationName;

            return application;
        }
    }
}
