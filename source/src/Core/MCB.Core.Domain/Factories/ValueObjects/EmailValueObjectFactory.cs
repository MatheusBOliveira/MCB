using MCB.Core.Domain.Factories.ValueObjects.Interfaces;
using MCB.Core.Domain.ValueObjects;
using MCB.Core.Infra.CrossCutting.Patterns.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Core.Domain.Factories.ValueObjects
{
    public class EmailValueObjectFactory
        : FactoryBase<EmailValueObject>,
        IEmailValueObjectFactory
    {
        public override EmailValueObject Create()
        {
            return new EmailValueObject();
        }

        public EmailValueObject Create(string parameter)
        {
            var returnObject = Create();

            returnObject.EmailAddress = parameter;

            return returnObject;
        }
    }
}
