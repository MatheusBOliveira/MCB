using MCB.Admin.Domain.DomainModels;
using MCB.Admin.Domain.Factories.DomainModels.Interfaces;
using MCB.Core.Domain.DomainModels.Base;
using MCB.Core.Domain.DomainModels.Interfaces;
using MCB.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MCB.Admin.Domain.DomainModels
{
    public class Application
        : DomainModelBase,
        IApplication
    {
        // Properties
        public Guid AppToken { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ActivableInfoValueObject ActivableInfo { get; set; }

        // Navigation Properties
        public Customer Customer { get; set; }
        public ICollection<ApplicationUser> ApplicationUserCollection { get; set; }

        public Application()
        {
            ActivableInfo = new ActivableInfoValueObject();
            ApplicationUserCollection = new List<ApplicationUser>();
        }

        public void Register(
            Customer customer,
            User user,
            string registrationUsername,
            IApplicationUserFactory applicationUserFactory,
            CultureInfo culture)
        {
            DomainModel.Id = Guid.NewGuid();

            Customer = customer;

            // Generate the application user
            var applicationUser = applicationUserFactory.Create((user, this), culture);
            ApplicationUserCollection = new List<ApplicationUser>
            {
                applicationUser
            };

            ActivableInfo = new ActivableInfoValueObject();
            ActivableInfo.Activate(registrationUsername);

        }
    }
}
