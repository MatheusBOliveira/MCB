using MCB.Admin.Domain.DomainModels;
using MCB.Admin.Domain.Services.Interfaces;
using MCB.Core.Domain.Services.Base;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Saga.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Admin.Domain.Services
{
    public class CustomerService
        : ServiceBase,
        ICustomerService
    {
        public CustomerService(ISagaManager sagaManager) 
            : base(sagaManager)
        {

        }
        public Customer ActiveCustomer(Customer customer)
        {
            // Validations

            // Business Process

            // Return
            return customer;
        }
        public Customer InactiveCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
        public Customer RegisterNewCustomer(Customer customer)
        {
            // Validations

            // Business Process

            // Return
            return customer;
        }
        public Customer RemoveCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
