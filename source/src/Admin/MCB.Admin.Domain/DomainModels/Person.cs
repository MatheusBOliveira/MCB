using MCB.Core.Domain.DomainModels.Base;
using MCB.Core.Domain.DomainModels.Enums;
using MCB.Core.Domain.DomainModels.Interfaces;
using MCB.Core.Domain.DomainModels.Interfaces.Base;
using MCB.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Admin.Domain.DomainModels
{
    public abstract class Person
        : DomainModelBase,
        IPerson,
        IActivableDomainModel
    {
        public PersonTypeEnum PersonType { get; set; }
        public string Name { get; set; }
        public GovernamentalNumberValueObject GovernamentalDocument { get; set; }

        public ActivableInfoValueObject ActivableInfo { get; set; }

        protected Person(PersonTypeEnum personType)
            : base()
        {
            ActivableInfo = new ActivableInfoValueObject();

            PersonType = personType;
        }
    }
}
