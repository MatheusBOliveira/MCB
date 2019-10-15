using System;

namespace MCB.Core.Infra.CrossCutting.Patterns.Tests.DomainModels
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid OwnerCustomerId { get; set; }

        public Customer OwnerCustomer { get; set; }
    }
}


