using System;

namespace MCB.Domain.DomainModels
{
    public abstract class DoctorRecordsItem : DomainModelBase
    {
        public DateTime DateAndTime { get; set; }
        public string Notes { get; set; }
        public DoctorRecords Records { get; set; }
    }
}

