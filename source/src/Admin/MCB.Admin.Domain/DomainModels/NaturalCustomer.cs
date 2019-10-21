using System;
using System.Collections.Generic;
using System.Text;
using MCB.Core.Domain.DomainModels.Enums;

namespace MCB.Admin.Domain.DomainModels
{
    public class NaturalCustomer
        : Customer
    {
        public NaturalCustomer() 
            : base(PersonTypeEnum.Natural)
        {
        }
    }
}
