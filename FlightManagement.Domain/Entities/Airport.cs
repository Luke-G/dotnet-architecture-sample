using System;
using FlightManagement.Domain.Entities.Common;

namespace FlightManagement.Domain.Entities
{
    public class Airport : AuditableEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string IcaoCode { get; set; }

        public string IataCode { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}