using MCB.Admin.Domain.DomainModels;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events.Interfaces;

namespace MCB.Admin.Domain.Events.Customers.Interfaces
{
    public interface ICustomerRegistrationSuccessfulEvent
        : IEvent
    {
        Customer RegisteredCustomer { get; set; }
    }
}