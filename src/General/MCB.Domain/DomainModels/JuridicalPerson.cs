using MCB.Domain.DomainModels.Enums;

namespace MCB.Domain.DomainModels
{
    public abstract class JuridicalPerson
        : Person
    {
        public JuridicalPersonTypeEnum JuridicalPersonType { get; private set; }

        public JuridicalPerson(JuridicalPersonTypeEnum juridicalPersonType)
            : base(PersonTypeEnum.JuridicalPerson)
        {
            JuridicalPersonType = juridicalPersonType;
        } 
    }
}

