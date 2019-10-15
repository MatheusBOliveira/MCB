using MCB.Core.Domain.ValueObjects;
using MCB.Domain.DomainModels.Enums;
using System.Collections.Generic;

namespace MCB.Domain.DomainModels
{
    public abstract class Person
        : DomainModelBase
    {
        public PersonTypeEnum PersonType { get; private set; }

        public string Name { get; set; }
        public EmailValueObject Email { get; set; }
        public ICollection<PersonRegistry> Registries { get; set; }

        public Person(PersonTypeEnum personType)
        {
            PersonType = personType;

            Email = new EmailValueObject();
        }
    }
}

