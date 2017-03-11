using System;

namespace AboutTime.Interfaces
{
    public interface IConnector
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string ConnectionString { get; set; }
    }
}