using MCB.Admin.Domain.DomainModels;

namespace MCB.Admin.Domain.Events.Customers.Interfaces
{
    public interface ICustomerRemoveFailEvent
    {
        Customer Customer { get; set; }
    }
}