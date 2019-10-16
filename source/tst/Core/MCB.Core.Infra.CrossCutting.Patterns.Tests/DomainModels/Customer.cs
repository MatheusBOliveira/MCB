using System;

namespace MCB.Core.Infra.CrossCutting.Patterns.Tests.DomainModels
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public User OwnedUser { get; set; }

        public Customer()
        {
            OwnedUser = new User();
        }

        public void Register()
        {
            Id = Guid.NewGuid();
        }
        public void RegisterNewOwnedUser(User user)
        {
            OwnedUser = user;
            user.OwnerCustomer = this;
            user.OwnerCustomerId = Id;
        }
    }
}


