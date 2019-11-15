using MCB.Admin.Domain.DomainModels;

namespace MCB.Admin.Domain.Events.Customers.Interfaces
{
    public interface ICustomerRegistrationFailEvent
    {
        Customer Customer { get; set; }
    }
}