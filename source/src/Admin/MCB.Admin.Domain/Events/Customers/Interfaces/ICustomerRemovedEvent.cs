using MCB.Admin.Domain.DomainModels;

namespace MCB.Admin.Domain.Events.Customers.Interfaces
{
    public interface ICustomerRemovedEvent
    {
        Customer RemovedCustomer { get; set; }
    }
}