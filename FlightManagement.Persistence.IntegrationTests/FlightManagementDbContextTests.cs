using System;
using System.Threading.Tasks;
using FlightManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;

namespace FlightManagement.Persistence.IntegrationTests
{
    public class FlightManagementDbContextTests
    {
        private readonly FlightManagementDbContext _dbContext;

        public FlightManagementDbContextTests()
        {
            DbContextOptions<FlightManagementDbContext> dbContextOptions = new DbContextOptionsBuilder<FlightManagementDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _dbContext = new FlightManagementDbContext(dbContextOptions);
        }

        [Fact]
        public async Task Save_SetCreatedAtProperty()
        {
            var airport = new Airport
            {
                Name = "Liverpool Airport",
                IcaoCode = "EGGP",
                IataCode = "LPL",
                Latitude = 52.345,
                Longitude = -3.24
            };

            _dbContext.Airports.Add(airport);
            await _dbContext.SaveChangesAsync();

            airport.CreatedAt.ToShortDateString().ShouldBe(DateTime.UtcNow.ToShortDateString());
        }
    }
}