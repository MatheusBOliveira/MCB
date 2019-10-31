using MCB.Admin.Domain.DomainModels;
using MCB.Core.Domain.Services.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Admin.Domain.Services.Interfaces
{
    public interface ICustomerService
        : IServiceBase
    {
        Customer ActiveCustomer(Customer customer);
        Customer InactiveCustomer(Customer customer);
        Customer RegisterNewCustomer(Customer customer);
        Customer RemoveCustomer(Customer customer);
    }
}
