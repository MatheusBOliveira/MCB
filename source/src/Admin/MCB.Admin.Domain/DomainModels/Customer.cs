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
        // Properties
        public EmailValueObject Email { get; set; }
        public PhoneNumberValueObject PhoneNumber { get; set; }

        // Navigation Properties
        public ICollection<User> UserCollection { get; set; }
        public ICollection<Application> ApplicationCollection { get; set; }

        protected Customer(PersonTypeEnum personType)
            : base(personType)
        {
            Email = new EmailValueObject();
            PhoneNumber = new PhoneNumberValueObject();

            UserCollection = new List<User>();
            ApplicationCollection = new List<Application>();
        }
    }
}
