using MCB.Admin.Domain.DomainModels;
using MCB.Admin.Domain.DomainModels.Enums;
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
        public ICollection<ApplicationFunction> ApplicationFunctionCollection { get; set; }
        public ICollection<ApplicationRole> ApplicationRoleCollection { get; set; }

        public Application()
        {
            ActivableInfo = new ActivableInfoValueObject();
            ApplicationUserCollection = new List<ApplicationUser>();
            ApplicationFunctionCollection = new List<ApplicationFunction>();
            ApplicationRoleCollection = new List<ApplicationRole>();
        }

        public void RegisterNewApplication(
            Customer customer,
            User user,
            string registrationUsername,
            IApplicationUserFactory applicationUserFactory,
            IApplicationFunctionFactory applicationFunctionFactory,
            IApplicationRoleFactory applicationRoleFactory,
            CultureInfo culture)
        {
            DomainModel.Id = Guid.NewGuid();
            Customer = customer;
            AuditableInfo = new AuditableInfoValueObject
            {
                CreatedUser = registrationUsername,
                CreatedDate = DateTime.UtcNow,
            };

            // Create admin application function
            var applicationFunction = applicationFunctionFactory.Create(culture);
            applicationFunction.DomainModel.Id = Guid.NewGuid();
            applicationFunction.Name = "admin";
            applicationFunction.AuditableInfo = new AuditableInfoValueObject
            {
                CreatedUser = registrationUsername,
                CreatedDate = DateTime.UtcNow,
            };
            applicationFunction.ApplicationFunctionType = ApplicationFunctionTypeEnum.GrantAll;

            // Associate creted application function with application
            applicationFunction.Application = this;
            ApplicationFunctionCollection.Add(applicationFunction);

            // Create admin application role
            var applicationRole = applicationRoleFactory.Create(culture);
            applicationRole.DomainModel.Id = Guid.NewGuid();
            applicationRole.Name = "admin";
            applicationRole.AuditableInfo = new AuditableInfoValueObject
            {
                CreatedUser = registrationUsername,
                CreatedDate = DateTime.UtcNow,
            };

            // Associate Application Role with Application
            applicationRole.Application = this;
            ApplicationRoleCollection.Add(applicationRole);

            // Create admin application user
            var applicationUser = applicationUserFactory.Create((user, this), culture);
            applicationUser.AuditableInfo = new AuditableInfoValueObject
            {
                CreatedUser = registrationUsername,
                CreatedDate = DateTime.UtcNow,
            };
            applicationUser.ActivableInfo.Activate(registrationUsername);

            // Associate appliation user with user and application
            applicationUser.User = user;
            applicationUser.Application = this;
            ApplicationUserCollection.Add(applicationUser);

            ActivableInfo.Activate(registrationUsername);
        }
    }
}
