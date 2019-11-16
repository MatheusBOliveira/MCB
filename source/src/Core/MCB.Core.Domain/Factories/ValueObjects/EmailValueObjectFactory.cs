using MCB.Core.Domain.Factories.ValueObjects.Interfaces;
using MCB.Core.Domain.ValueObjects;
using MCB.Core.Infra.CrossCutting.Patterns.Factory;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MCB.Core.Domain.Factories.ValueObjects
{
    public class EmailValueObjectFactory
        : FactoryBase<EmailValueObject>,
        IEmailValueObjectFactory
    {
        public override EmailValueObject Create(CultureInfo culture)
        {
            return new EmailValueObject();
        }

        public EmailValueObject Create(string parameter, CultureInfo culture)
        {
            var returnObject = Create(culture);

            returnObject.EmailAddress = parameter;

            return returnObject;
        }
    }
}
