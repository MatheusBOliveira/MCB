using MCB.Admin.Domain.DomainModels.Enums;
using MCB.Core.Domain.DomainModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Admin.Domain.DomainModels
{
    public class ApplicationFunction
        : DomainModelBase
    {
        // Properties
        public string Name { get; set; }
        public ApplicationFunctionTypeEnum ApplicationFunctionType { get; set; }
        public string Description { get; set; }

        // Navigation Properties
        public Application Application { get; set; }
        public ICollection<ApplicationRole> ApplicationRoleCollection { get; set; }

        public ApplicationFunction()
        {
            Application = new Application();
            ApplicationRoleCollection = new List<ApplicationRole>();
        }
    }
}
