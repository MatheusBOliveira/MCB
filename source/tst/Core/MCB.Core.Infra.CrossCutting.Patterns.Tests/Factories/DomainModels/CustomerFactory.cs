using MCB.Core.Infra.CrossCutting.Patterns.Factory;
using MCB.Core.Infra.CrossCutting.Patterns.Factory.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.Tests.Commands;
using MCB.Core.Infra.CrossCutting.Patterns.Tests.DomainModels;
using System.Globalization;

namespace MCB.Core.Infra.CrossCutting.Patterns.Tests.Factories.DomainModels
{
    public class CustomerFactory
        : FactoryBase<Customer>,
        IFactoryWithParameter<Customer, RegisterNewCustomerCommand>,
        IFactory<Customer>
    {
        public override Customer Create(CultureInfo cultureInfo)
        {
            return new Customer();
        }

        public Customer Create(CultureInfo cultureInfo, RegisterNewCustomerCommand parameter)
        {
            var customer = Create(cultureInfo);
            customer.Name = parameter.Name;
            customer.Email = parameter.Email;

            return customer;
        }
    }
}


