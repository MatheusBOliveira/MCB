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
        public Guid CustomerId { get; set; }
        public EmailValueObject Email { get; set; }
        public PasswordValueObject Password { get; set; }
        public ActivableInfoValueObject ActivableInfo { get; set; }

        public Customer Customer { get; set; }

        public User() : base()
        {
            ActivableInfo = new ActivableInfoValueObject();
        }
    }
}
