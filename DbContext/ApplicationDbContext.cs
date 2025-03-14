using DbContext.Entities;
using Microsoft.EntityFrameworkCore;


namespace Entities
{
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<RideData> RideData { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Creating an index for PULocationID
            modelBuilder.Entity<RideData>()
                .HasIndex(r => r.PULocationID)
                .HasDatabaseName("IDX_PULocationID");

            // Creating an index for TripDistance
            modelBuilder.Entity<RideData>()
                .HasIndex(r => r.TripDistance)
                .HasDatabaseName("IDX_TripDistance");

            // Creating an index for trip time (based on TpepPickupDatetime and TpepDropoffDatetime)
            modelBuilder.Entity<RideData>()
                .HasIndex(r => new { r.TpepPickupDatetime, r.TpepDropoffDatetime })
                .HasDatabaseName("IDX_TravelTime");
        }
    }
}
