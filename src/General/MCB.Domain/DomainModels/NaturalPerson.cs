using MCB.Domain.DomainModels.Enums;

namespace MCB.Domain.DomainModels
{
    public abstract class NaturalPerson
        : Person
    {
        public NaturalPersonTypeEnum NaturalPersonType { get; private set; }
        public Profession Profession { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string SocialName { get; set; }

        public NaturalPerson(NaturalPersonTypeEnum naturalPersonType)
            : base(PersonTypeEnum.NaturalPerson)
        {
            NaturalPersonType = naturalPersonType;
        } 
    }
}

