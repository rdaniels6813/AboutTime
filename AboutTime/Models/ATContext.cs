using Microsoft.EntityFrameworkCore;

namespace AboutTime.Models
{
    public class ATContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=AboutTime.db");
        }
        public DbSet<Connector> Connectors { get; set; }
        public DbSet<TimeCard> TimeCards { get; set; }
    }
}
