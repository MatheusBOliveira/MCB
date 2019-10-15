using System;

namespace MCB.Domain.DomainModels
{
    public class ScheduleItem
        : DomainModelBase
    {
        public DateTime DateAndTime { get; set; }
        public Consultation Consultation { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public Schedule Schedule { get; set; }
    }
}

