using MCB.Admin.Domain.DomainModels;
using MCB.Admin.Domain.Services.Interfaces;
using MCB.Admin.Domain.Validations.Customers;
using MCB.Admin.Domain.Validations.Customers.Interfaces;
using MCB.Core.Domain.Services.Base;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Saga.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace MCB.Admin.Domain.Services
{
    public class CustomerService
        : ServiceBase,
        ICustomerService
    {
        private readonly ICustomerIsValidForRegistrationValidation _customerIsValidForRegistrationValidation;

        public CustomerService(
            ISagaManager sagaManager,
            ICustomerIsValidForRegistrationValidation customerIsValidForRegistrationValidation
            ) 
            : base(sagaManager)
        {
            _customerIsValidForRegistrationValidation = customerIsValidForRegistrationValidation;
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
        public async Task<Customer> RegisterNewCustomer(Customer customer, string registrationUsername, CultureInfo culture)
        {
            customer.DomainModel.ValidationResult = await _customerIsValidForRegistrationValidation.Validate(customer, culture);
            if (!customer.DomainModel.IsValid())
            {
                NotifyValidationErrors(customer.DomainModel.ValidationResult, culture);
                return await Task.FromResult(customer);
            }

            customer.RegisterNewCustomer(registrationUsername);

            return await Task.FromResult(customer);
        }
        public Customer RemoveCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
