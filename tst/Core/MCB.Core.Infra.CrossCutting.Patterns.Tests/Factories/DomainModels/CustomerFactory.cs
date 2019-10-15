using MCB.Core.Infra.CrossCutting.Patterns.Factory;
using MCB.Core.Infra.CrossCutting.Patterns.Factory.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.Tests.Commands;
using MCB.Core.Infra.CrossCutting.Patterns.Tests.DomainModels;

namespace MCB.Core.Infra.CrossCutting.Patterns.Tests.Factories.DomainModels
{
    public class CustomerFactory
        : FactoryBase<Customer>,
        IFactoryWithParameter<Customer, RegisterNewCustomerCommand>,
        IFactory<Customer>
    {
        public override Customer Create()
        {
            return new Customer();
        }

        public Customer Create(RegisterNewCustomerCommand parameter)
        {
            var customer = Create();
            customer.Name = parameter.Name;
            customer.Email = parameter.Email;

            return customer;
        }
    }
}


