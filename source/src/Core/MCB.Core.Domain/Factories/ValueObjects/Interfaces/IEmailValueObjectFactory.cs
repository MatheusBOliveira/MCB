using MCB.Core.Domain.ValueObjects;
using MCB.Core.Infra.CrossCutting.Patterns.Factory.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Core.Domain.Factories.ValueObjects.Interfaces
{
    public interface IEmailValueObjectFactory
        : IFactory<EmailValueObject>,
        IFactoryWithParameter<EmailValueObject, string>
    {
    }
}
