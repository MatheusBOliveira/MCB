namespace MCB.Domain.DomainModels
{
    public abstract class DoctorRecords
        : DomainModelBase
    {
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
    }
}

