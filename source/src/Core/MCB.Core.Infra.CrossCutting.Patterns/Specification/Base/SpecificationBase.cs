using MCB.Core.Infra.CrossCutting.Patterns.Specification.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Patterns.Specification.Base
{
    public abstract class SpecificationBase<T>
        : ISpecification<T>
    {
        public string ErrorCode { get; set; }
        public string ErrorDefaultDescription { get; set; }

        protected SpecificationBase()
        {
            ErrorCode = ErrorDefaultDescription = this.GetType().Name;
        }

        public abstract Task<bool> IsSatisfiedBy(T entity, CultureInfo culture);
    }
}
