using AboutTime.Interfaces;
using System;

namespace AboutTime.Models
{
    public class Connector : IConnector
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ConnectionString { get; set; }
    }
}
