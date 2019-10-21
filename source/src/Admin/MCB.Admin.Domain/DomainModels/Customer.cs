using MCB.Core.Domain.DomainModels.Base;
using MCB.Core.Domain.DomainModels.Enums;
using MCB.Core.Domain.DomainModels.Interfaces;
using MCB.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Admin.Domain.DomainModels
{
    public abstract class Customer
        : Person,
        ICustomer
    {
        public string Name { get; set; }

        public ICollection<User> UserCollection { get; set; }

        protected Customer(PersonTypeEnum personType)
            : base(personType)
        {
            ActivableInfo = new ActivableInfoValueObject();
            PersonType = personType;
        }
    }
}
