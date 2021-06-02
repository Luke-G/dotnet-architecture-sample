using System;
using System.Collections.Generic;
using FlightManagement.Core.Application.Contracts.Persistence;
using FlightManagement.Domain.Entities;
using Moq;

namespace FlightManagement.Application.UnitTests.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IAirportRepository> GetAirportRepository()
        {
            var airports = new List<Airport>
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
            };

            var mockAirportsRepository = new Mock<IAirportRepository>();
            mockAirportsRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(airports);

            mockAirportsRepository.Setup(repo => repo.AddAsync(It.IsAny<Airport>())).ReturnsAsync((Airport airport) =>
            {
                airports.Add(airport);
                return airport;
            });

            return mockAirportsRepository;
        }
    }
}