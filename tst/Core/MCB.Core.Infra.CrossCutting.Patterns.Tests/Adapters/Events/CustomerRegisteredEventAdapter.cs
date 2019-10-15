using MCB.Core.Infra.CrossCutting.Patterns.Adapter;
using MCB.Core.Infra.CrossCutting.Patterns.Adapter.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.Tests.DomainModels;
using MCB.Core.Infra.CrossCutting.Patterns.Tests.Events;

namespace MCB.Core.Infra.CrossCutting.Patterns.Tests.Adapters.Events
{
    public class CustomerRegisteredEventAdapter
        : AdapterBase,
        IAdapter<CustomerRegisteredEvent, Customer>,
        IAdapter<CustomerRegisteredEvent, User>
    {
        public CustomerRegisteredEvent Adapt(CustomerRegisteredEvent target, Customer source)
        {
            target.Customer = source;

            return target;
        }

        public CustomerRegisteredEvent Adapt(CustomerRegisteredEvent target, User source)
        {
            target.User = source;

            return target;
        }
    }
}


