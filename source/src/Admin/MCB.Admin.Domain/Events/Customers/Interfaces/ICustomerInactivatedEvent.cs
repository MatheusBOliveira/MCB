using MCB.Admin.Domain.DomainModels;

namespace MCB.Admin.Domain.Events.Customers.Interfaces
{
    public interface ICustomerInactivatedEvent
    {
        Customer InactivatedCustomer { get; set; }
    }
}