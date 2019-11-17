using MCB.Core.Domain.DomainModels.Base;
using MCB.Core.Domain.DomainModels.Interfaces;
using MCB.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Admin.Domain.DomainModels
{
    public class User
        : DomainModelBase,
        IUser
    {
        // Properties
        public string Username { get; set; }
        public PasswordValueObject Password { get; set; }
        public EmailValueObject Email { get; set; }
        public ActivableInfoValueObject ActivableInfo { get; set; }

        // Navigation Properties
        public Customer Customer { get; set; }
        public ICollection<ApplicationUser> ApplicationUserCollection { get; set; }

        public User() : base()
        {
            Email = new EmailValueObject();
            ActivableInfo = new ActivableInfoValueObject();

            ApplicationUserCollection = new List<ApplicationUser>();
        }

        public void Register(Customer customer, string registrationUsername)
        {
            DomainModel.Id = Guid.NewGuid();

            Customer = customer;
            customer.AdminUser = this;
            customer.UserCollection.Add(this);

            ActivableInfo = new ActivableInfoValueObject();
            ActivableInfo.Activate(registrationUsername);
        }
    }
}
