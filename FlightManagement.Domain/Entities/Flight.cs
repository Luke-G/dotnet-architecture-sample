using System;
using FlightManagement.Domain.Entities.Common;

namespace FlightManagement.Domain.Entities
{
    public class Flight : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Callsign { get; set; }
        public string FlightNumber { get; set; }
        public Guid DepartureAirportId { get; set; }
        public Airport DepartureAirport { get; set; }
        public Guid ArrivalAirportId { get; set; }
        public Airport ArrivalAirport { get; set; }
    }
}