using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FlightManagement.Domain.Entities;
using FlightManagement.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FlightManagement.Persistence
{
    public class FlightManagementDbContext : DbContext
    {
        public FlightManagementDbContext(DbContextOptions<FlightManagementDbContext> options) :
            base(options)
        {
        }

        public DbSet<Airport> Airports { get; set; }
        public DbSet<Flight> Flights { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(FlightManagementDbContext).Assembly);

            // Seed data.
            var departureAirportGuid = Guid.NewGuid();
            var arrivalAirportGuid = Guid.NewGuid();
            var flightGuid = Guid.NewGuid();

            builder.Entity<Airport>().HasData(new Airport
            {
                Id = departureAirportGuid,
                Name = "Manchester Airport",
                IcaoCode = "EGCC",
                IataCode = "MAN",
                Latitude = 52.41,
                Longitude = -3.246
            });

            builder.Entity<Airport>().HasData(new Airport
            {
                Id = arrivalAirportGuid,
                Name = "Newcastle Airport",
                IcaoCode = "EGNT",
                IataCode = "NCL",
                Latitude = 50.41,
                Longitude = -2.1
            });

            builder.Entity<Flight>().HasData(new Flight
            {
                Id = flightGuid,
                Callsign = "BAW387",
                FlightNumber = "BA387",
                DepartureAirportId = departureAirportGuid,
                ArrivalAirportId = arrivalAirportGuid
            });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            foreach (EntityEntry<AuditableEntity> entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedAt = DateTime.UtcNow;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}

