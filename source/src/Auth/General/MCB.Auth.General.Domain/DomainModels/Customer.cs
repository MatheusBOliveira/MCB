using MCB.Core.Domain.DomainModels.Enums;
using MCB.Core.Domain.DomainModels.Interfaces;
using MCB.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Auth.General.Domain.DomainModels
{
    public class Customer
        : ICustomer
    {
        public string Name { get; set; }
        public PersonTypeEnum PersonType { get; set; }
        public string GovernamentalDocumentNumber { get; set; }

        public DomainModelValueObject DomainModel { get; set; }
        public ActivableInfoValueObject ActivableInfo { get; set; }

        public Customer()
        {
            DomainModel = new DomainModelValueObject();
            ActivableInfo = new ActivableInfoValueObject();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
