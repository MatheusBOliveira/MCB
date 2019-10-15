namespace MCB.Domain.DomainModels
{
    public class Patient
        : NaturalPerson
    {
        public Patient()
            : base(Enums.NaturalPersonTypeEnum.Patient)
        {

        } 
    }
}

