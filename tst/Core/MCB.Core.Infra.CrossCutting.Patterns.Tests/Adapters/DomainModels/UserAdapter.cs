using MCB.Core.Infra.CrossCutting.Patterns.Adapter;
using MCB.Core.Infra.CrossCutting.Patterns.Adapter.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.Tests.Commands;
using MCB.Core.Infra.CrossCutting.Patterns.Tests.DomainModels;

namespace MCB.Core.Infra.CrossCutting.Patterns.Tests.Adapters.DomainModels
{
    public class UserAdapter
        : AdapterBase,
        IAdapter<User, RegisterNewCustomerCommand>
    {
        public User Adapt(User target, RegisterNewCustomerCommand source)
        {
            target.Username = source.Email;
            target.Password = source.Password;

            return target;
        }
    }
}


