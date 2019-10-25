using MCB.Core.Domain.DomainModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Admin.Domain.DomainModels
{
    public class ApplicationUserSession
        : DomainModelBase
    {
        // Properties
        public string SessionToken { get; set; }
        public DateTime ExpirationDate { get; set; }

        // Navigation Properties
        public ApplicationUser ApplicationUser { get; set; }

        public ApplicationUserSession()
        {
            ApplicationUser = new ApplicationUser();
        }
    }
}
