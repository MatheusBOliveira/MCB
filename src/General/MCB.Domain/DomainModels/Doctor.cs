using MCB.Domain.DomainModels.Enums;
using System.Collections.Generic;

namespace MCB.Domain.DomainModels
{
    public abstract class Doctor
        : NaturalPerson
    {
        public ICollection<Specialty> Specialties { get; set; }

        public Doctor()
            : base(NaturalPersonTypeEnum.Doctor)
        {

        } 
    }
}

