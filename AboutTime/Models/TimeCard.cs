using System;
using AboutTime.Interfaces;

namespace AboutTime.Models
{
    public class TimeCard : ITimeCard
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
