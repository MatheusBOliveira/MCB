using System;
using System.Collections.Generic;

namespace MCB.Core.Infra.CrossCutting.Patterns.Tests.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public List<string> Roles { get; set; }

        public Customer()
        {
            Roles = new List<string>();
        }
    }
}


