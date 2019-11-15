using MCB.Admin.Domain.DomainModels;

namespace MCB.Admin.Domain.Events.Customers.Interfaces
{
    public interface ICustomerInactivationFailEvent
    {
        Customer Customer { get; set; }
    }
}