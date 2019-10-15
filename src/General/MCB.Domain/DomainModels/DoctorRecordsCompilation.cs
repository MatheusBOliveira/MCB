using System;
using System.Collections.Generic;

namespace MCB.Domain.DomainModels
{
    public class DoctorRecordsCompilation : DomainModelBase
    {
        public DateTime DateAndTime { get; set; }
        public Doctor Doctor { get; set; }

        public ICollection<DoctorRecords> Records { get; set; }
    }
}

