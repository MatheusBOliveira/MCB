using MCB.Admin.Domain.Commands.Customers;
using MCB.Admin.Domain.DomainModels;
using MCB.Admin.Domain.Factories.DomainModels.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.Factory;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MCB.Admin.Domain.Factories.DomainModels
{
    public class UserFactory
        : FactoryBase<User>,
        IUserFactory
    {
        public override User Create(CultureInfo culture)
        {
            return new User();
        }

        public User Create(RegisterNewCustomerCommand parameter, CultureInfo culture)
        {
            var user = Create(culture);

            user.Username = parameter.Username;
            user.Password = parameter.Password;
            user.Email = parameter.Email;

            return user;
        }
    }
}
