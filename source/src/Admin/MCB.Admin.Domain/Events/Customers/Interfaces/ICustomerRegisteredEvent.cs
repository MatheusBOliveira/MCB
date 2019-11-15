using MCB.Admin.Domain.DomainModels;

namespace MCB.Admin.Domain.Events.Customers.Interfaces
{
    public interface ICustomerRegisteredEvent
    {
        Customer RegisteredCustomer { get; set; }
    }
}