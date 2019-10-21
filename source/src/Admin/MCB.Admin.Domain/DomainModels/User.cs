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
        public Guid CustomerId { get; set; }
        public EmailValueObject Email { get; set; }
        public ActivableInfoValueObject ActivableInfo { get; set; }

        // Navigation Properties
        public Customer Customer { get; set; }
        public List<ApplicationUser> ApplicationUserCollection { get; set; }

        public User() : base()
        {
            Email = new EmailValueObject();
            ActivableInfo = new ActivableInfoValueObject();
            ApplicationUserCollection = new List<ApplicationUser>();
        }
    }
}
