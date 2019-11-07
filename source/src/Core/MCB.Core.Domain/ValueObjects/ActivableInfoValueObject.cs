using MCB.Core.Domain.DomainModels.Interfaces.Base;
using MCB.Core.Domain.ValueObjects.Base;
using System;

namespace MCB.Core.Domain.ValueObjects
{
    public class ActivableInfoValueObject
        : ValueObjectBase
    {
        public bool IsActive { get; set; }

        public string ActivationUser { get; set; }
        public DateTime? ActivationDate { get; set; }

        public string InactivationUser { get; set; }
        public DateTime? InactivationDate { get; set; }

        public void Activate(string activationUser = null)
        {
            IsActive = true;

            if (!string.IsNullOrWhiteSpace(activationUser))
                ActivationUser = activationUser;

            ActivationDate = DateTime.UtcNow;
        }
        public void Inactivate(string inactivationUser = null)
        {
            IsActive = false;

            if (!string.IsNullOrWhiteSpace(inactivationUser))
                InactivationUser = inactivationUser;

            InactivationDate = DateTime.UtcNow;
        }

        public void SetActivableInfoForCollection(IActivableDomainModel[] activableDomainModelCollection)
        {
            for (var i = 0; i < activableDomainModelCollection.Length; i++)
                activableDomainModelCollection[i].ActivableInfo = this;
        }

        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}

