using MCB.Admin.Domain.DomainModels;
using MCB.Admin.Domain.Factories.DomainModels.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.Factory;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MCB.Admin.Domain.Factories.DomainModels
{
    public class ApplicationFunctionFactory
        : FactoryBase<ApplicationFunction>,
        IApplicationFunctionFactory
    {
        public override ApplicationFunction Create(CultureInfo culture)
        {
            return new ApplicationFunction();
        }
    }
}
