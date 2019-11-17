using MCB.Admin.Domain.DomainModels;
using MCB.Core.Domain.Services.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace MCB.Admin.Domain.Services.Interfaces
{
    public interface IUserService
        : IService
    {
        Task<User> RegisterNewUser(User user, Customer customer, string registrationUsername, CultureInfo culture);
    }
}
