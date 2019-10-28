using MCB.Core.Infra.CrossCutting.Patterns.Specification.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Admin.Domain.Specifications.Commands.Customers.Base.Interfaces
{
    public interface IEmailMustNotExistsInRepositorySpecification
        : ISpecification<string>
    {
    }
}
