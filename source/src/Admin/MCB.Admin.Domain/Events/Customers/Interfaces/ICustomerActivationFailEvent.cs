using MCB.Admin.Domain.DomainModels;

namespace MCB.Admin.Domain.Events.Customers.Interfaces
{
    public interface ICustomerActivationFailEvent
    {
        Customer Customer { get; set; }
    }
}