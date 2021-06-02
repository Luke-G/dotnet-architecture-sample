using System;

namespace FlightManagement.Domain.Entities.Common
{
    public class AuditableEntity
    {
        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? LastModifiedAt { get; set; }
    }
}