using MCB.Core.Infra.CrossCutting.Patterns.Specification.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Core.Infra.CrossCutting.Patterns.CQRS.Queries.Interfaces
{
    public interface IQuery
        : IDisposable,
        ISelfValidator
    {
    }
}
