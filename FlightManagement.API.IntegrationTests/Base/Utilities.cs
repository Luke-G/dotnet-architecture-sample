using System;
using System.Collections.Generic;
using FlightManagement.Persistence;
using FlightManagement.Domain.Entities;

namespace FlightManagement.API.IntegrationTests.Base
{
    public static class Utilities
    {
        public static void InitializeDbForTests(FlightManagementDbContext context)
        {
            context.Airports.AddRange(new List<Airport>
            {
                new()
                {
                    Id = Guid.Empty,
                    Name = "Manchester Airport",
                    IcaoCode = "EGCC",
                    IataCode = "MAN",
                    Latitude = 52.41,
                    Longitude = -3.246
                },
                new()
                {
                    Id = Guid.Empty,
                    Name = "Newcastle Airport",
                    IcaoCode = "EGNT",
                    IataCode = "NCL",
                    Latitude = 50.41,
                    Longitude = -2.1
                }
            });

            context.SaveChanges();
        }
    }
}