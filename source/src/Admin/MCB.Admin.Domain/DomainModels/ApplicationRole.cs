using MCB.Core.Domain.DomainModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Admin.Domain.DomainModels
{
    public class ApplicationRole
        : DomainModelBase
    {
        // Properties
        public string Name { get; set; }
        public string Description { get; set; }

        // Navigation Properties
        public Application Application { get; set; }
        public ICollection<ApplicationFunction> ApplicationFunctionCollection { get; set; }
        public ICollection<ApplicationUser> ApplicationUserCollection { get; set; }

        public ApplicationRole()
        {
            Application = new Application();
            ApplicationFunctionCollection = new List<ApplicationFunction>();
            ApplicationUserCollection = new List<ApplicationUser>();
        }
    }
}
