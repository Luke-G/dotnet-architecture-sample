using System;
using MediatR;

namespace FlightManagement.Application.Features.Airports.Commands.CreateAirport
{
    public class CreateAirportCommand : IRequest<CreateAirportCommandResponse>
    {
        public string Name { get; set; }
        public string IcaoCode { get; set; }
        public string IataCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public override string ToString() => $"Event: {Name}. Icao: {IcaoCode}. Iata: {IataCode}. Position: {Latitude}, {Longitude}.";
    }
}