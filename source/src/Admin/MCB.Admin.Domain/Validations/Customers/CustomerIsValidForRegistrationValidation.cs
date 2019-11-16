using MCB.Admin.Domain.DomainModels;
using MCB.Admin.Domain.Specifications.Customers.Interfaces;
using MCB.Admin.Domain.Validations.Customers.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.Specification;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Admin.Domain.Validations.Customers
{
    public class CustomerIsValidForRegistrationValidation
        : Validator<Customer>,
        ICustomerIsValidForRegistrationValidation
    {
        public CustomerIsValidForRegistrationValidation(
            ICustomerEmailIsRequiredSpecification customerEmailIsRequiredSpecification,
            ICustomerEmailMustBeUniqueInRepositorySpecification customerEmailMustBeUniqueInRepositorySpecification,
            ICustomerGovernamentalDocumentNumberIsRequiredSpecification customerGovernamentalDocumentNumberIsRequiredSpecification,
            ICustomerGovernamentalNumberForLegalPersonIsValidSpecification customerGovernamentalNumberForLegalPersonIsValidSpecification,
            ICustomerGovernamentalNumberForNaturalPersonIsValidSpecification customerGovernamentalNumberForNaturalPersonIsValidSpecification,
            ICustomerNameIsRequiredSpecification customerNameIsRequiredSpecification,
            ICustomerNameValidLengthSpecification customerNameValidLengthSpecification,
            ICustomerPhoneNumberIsRequiredSpecification customerPhoneNumberIsRequiredSpecification
            )
        {
            AddSpecification(customerEmailIsRequiredSpecification);
            AddSpecification(customerEmailMustBeUniqueInRepositorySpecification);
            AddSpecification(customerGovernamentalDocumentNumberIsRequiredSpecification);
            AddSpecification(customerGovernamentalNumberForLegalPersonIsValidSpecification);
            AddSpecification(customerGovernamentalNumberForNaturalPersonIsValidSpecification);
            AddSpecification(customerNameIsRequiredSpecification);
            AddSpecification(customerNameValidLengthSpecification);
            AddSpecification(customerPhoneNumberIsRequiredSpecification);
        }
    }
}
