using MCB.Admin.Domain.DomainModels;

namespace MCB.Admin.Domain.Events.Customers.Interfaces
{
    public interface ICustomerActivatedEvent
    {
        Customer ActivatedCustomer { get; set; }
    }
}