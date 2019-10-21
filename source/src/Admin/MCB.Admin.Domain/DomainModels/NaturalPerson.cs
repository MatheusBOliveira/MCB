using System;
using System.Collections.Generic;
using System.Text;
using MCB.Core.Domain.DomainModels.Enums;

namespace MCB.Admin.Domain.DomainModels
{
    public class NaturalPerson
        : Person
    {
        public NaturalPerson() 
            : base(PersonTypeEnum.Natural)
        {
        }
    }
}
