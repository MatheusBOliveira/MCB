using MCB.Core.Infra.CrossCutting.Patterns.Factory;
using MCB.Core.Infra.CrossCutting.Patterns.Factory.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.Tests.Commands;
using MCB.Core.Infra.CrossCutting.Patterns.Tests.DomainModels;
using System.Globalization;

namespace MCB.Core.Infra.CrossCutting.Patterns.Tests.Factories.DomainModels
{
    public class UserFactory
        : FactoryBase<User>,
        IFactoryWithParameter<User, RegisterNewCustomerCommand>,
        IFactory<User>
    {
        public override User Create(CultureInfo culture)
        {
            return new User();
        }

        public User Create(RegisterNewCustomerCommand parameter, CultureInfo culture)
        {
            var user = Create(culture);
            user.Username = parameter.Email;
            user.Password = parameter.Password;

            return user;
        }
    }
}


