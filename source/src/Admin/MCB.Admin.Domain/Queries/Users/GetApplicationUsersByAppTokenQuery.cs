using MCB.Admin.Domain.Queries.Users.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MCB.Admin.Domain.Queries.Users
{
    public class GetApplicationUsersByAppTokenQuery
        : QueryBase,
        IGetApplicationUsersByAppTokenQuery
    {
        public string AppToken { get; set; }

        public override void Validate()
        {
            ValidationResult = new Core.Infra.CrossCutting.Patterns.Specification.ValidationResult();
        }
    }
}
