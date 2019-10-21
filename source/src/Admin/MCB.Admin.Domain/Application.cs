using MCB.Admin.Domain.DomainModels;
using MCB.Core.Domain.DomainModels.Base;
using MCB.Core.Domain.DomainModels.Interfaces;
using MCB.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Admin.Domain
{
    public class Application
        : DomainModelBase,
        IApplication
    {
        // Properties
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public ActivableInfoValueObject ActivableInfo { get; set; }

        // Navigation Properties
        public Customer Customer { get; set; }
        public ICollection<ApplicationUser> ApplicationUserCollection { get; set; }


    }
}
