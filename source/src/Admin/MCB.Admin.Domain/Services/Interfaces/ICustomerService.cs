using MCB.Admin.Domain.DomainModels;
using MCB.Core.Domain.Services.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace MCB.Admin.Domain.Services.Interfaces
{
    public interface ICustomerService
        : IService
    {
        Customer ActiveCustomer(Customer customer);
        Customer InactiveCustomer(Customer customer);
        Task<Customer> RegisterNewCustomer(Customer customer, string registrationUsername, CultureInfo culture);
        Customer RemoveCustomer(Customer customer);
    }
}
