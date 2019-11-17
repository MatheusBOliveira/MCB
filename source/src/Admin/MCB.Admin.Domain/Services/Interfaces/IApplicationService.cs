using MCB.Admin.Domain.DomainModels;
using MCB.Admin.Domain.Factories.DomainModels.Interfaces;
using MCB.Core.Domain.Services.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace MCB.Admin.Domain.Services.Interfaces
{
    public interface IApplicationService
        : IService
    {
        Task<Application> RegisterNewApplication(
            Application application,
            Customer customer,
            User user,
            string registrationUsername,
            CultureInfo culture);
    }
}
