using System;

namespace MCB.Domain.DomainModels
{
    public class MedicalRecords : DoctorRecords
    {
        public DateTime DateAndTime { get; set; }
        public bool IsConfidential { get; set; }
    }
}

