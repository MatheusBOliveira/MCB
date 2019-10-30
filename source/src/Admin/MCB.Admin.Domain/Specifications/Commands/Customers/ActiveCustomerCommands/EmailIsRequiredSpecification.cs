using MCB.Admin.Domain.Commands.Customers;
using MCB.Admin.Domain.Specifications.Commands.Customers.ActiveCustomerCommands.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MCB.Admin.Domain.Specifications.Commands.Customers.ActiveCustomerCommands
{
    public class EmailIsRequiredSpecification
        : IEmailIsRequiredSpecification
    {
        public string ErrorCode => "MCB-ADMIN-DOMAIN-COMMANDS-3";
        public string ErrorDefaultDescription => nameof(EmailIsRequiredSpecification);

        public Task<bool> IsSatisfiedBy(ActiveCustomerCommand entity)
        {
            return Task.FromResult(!string.IsNullOrEmpty(entity?.Email?.EmailAddress));
        }
    }
}
