using System.Collections.Generic;
using System.Linq;

namespace MCB.Core.Infra.CrossCutting.Patterns.Specification
{
    public class ValidationResult
    {
        private readonly List<ValidationError> _errors = new List<ValidationError>();

        public string Message
        {
            get;
            set;
        }

        public bool IsValid
        {
            get
            {
                return _errors.Count == 0;
            }
        }

        public IEnumerable<ValidationError> Errors
        {
            get
            {
                return _errors;
            }
        }

        public void Add(ValidationError error)
        {
            _errors.Add(error);
        }

        public void Remove(ValidationError error)
        {
            if (_errors.Contains(error))
            {
                _errors.Remove(error);
            }
        }

        public void Add(params ValidationResult[] validationResults)
        {
            if (validationResults != null)
            {
                foreach (var item in from result in validationResults
                                     where result != null
                                     select result)
                {
                    _errors.AddRange(item.Errors);
                }
            }
        }
    }
}


