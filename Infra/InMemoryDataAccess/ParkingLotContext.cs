using Domain.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.InMemoryDataAccess
{
    public class ParkingLotContext : DbContext
    {

        public DbSet<Establishment> Establishments { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ParkingSpace> ParkingSpaces { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        
        public ParkingLotContext(DbContextOptions options) : base(options)
        {
        }
    }
}