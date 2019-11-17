using MCB.Core.Domain.DomainModels.Base;
using MCB.Core.Domain.DomainModels.Interfaces;
using MCB.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Admin.Domain.DomainModels
{
    public class ApplicationUser
        : DomainModelBase,
        IApplicationUser
    {
        // Navigation Properties
        public Application Application { get; set; }
        public User User { get; set; }
        public ActivableInfoValueObject ActivableInfo { get; set; }

        public ICollection<ApplicationUserSession> ApplicationUserSessionCollection { get; set; }
        public ICollection<ApplicationRole> ApplicationRoleCollection { get; set; }


        public ApplicationUser()
        {
            Application = new Application();
            User = new User();
            ActivableInfo = new ActivableInfoValueObject();

            ApplicationUserSessionCollection = new List<ApplicationUserSession>();
            ApplicationRoleCollection = new List<ApplicationRole>();
        }
    }
}
