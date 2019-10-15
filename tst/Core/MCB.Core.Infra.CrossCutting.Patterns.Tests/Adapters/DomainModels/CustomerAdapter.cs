using MCB.Core.Infra.CrossCutting.Patterns.Adapter;
using MCB.Core.Infra.CrossCutting.Patterns.Adapter.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.Tests.Commands;
using MCB.Core.Infra.CrossCutting.Patterns.Tests.DomainModels;

namespace MCB.Core.Infra.CrossCutting.Patterns.Tests.Adapters.DomainModels
{
    public class CustomerAdapter
        : AdapterBase,
        IAdapter<Customer, RegisterNewCustomerCommand>
    {
        public Customer Adapt(Customer target, RegisterNewCustomerCommand source)
        {
            target.Name = source.Name;
            target.Email = source.Email;

            return target;
        }
    }
}


