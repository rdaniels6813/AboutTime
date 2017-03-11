using System;

namespace AboutTime.Interfaces
{
    public interface ITimeCard
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
    }
}