using MCB.Admin.Domain.Queries.Customers.Interfaces;
using MCB.Core.Domain.ValueObjects;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Queries;
using MCB.Core.Infra.CrossCutting.Patterns.Specification;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MCB.Admin.Domain.Queries.Customers
{
    public class CheckIfEmailExistsInRepositoryQuery
        : QueryBase, 
        ICheckIfEmailExistsInRepositoryQuery
    {
        public EmailValueObject Email { get; set; }

        public override void Validate()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
