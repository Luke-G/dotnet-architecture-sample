using FlightManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightManagement.Persistence.Configurations
{
    public class AirportConfiguration : IEntityTypeConfiguration<Airport>
    {
        public void Configure(EntityTypeBuilder<Airport> builder)
        {
            builder.Property(q => q.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(q => q.IcaoCode)
                .IsRequired()
                .HasMaxLength(4);

            builder.Property(q => q.IataCode)
                .IsRequired()
                .HasMaxLength(3);

            builder.Property(q => q.Latitude)
                .IsRequired();

            builder.Property(q => q.Longitude)
                .IsRequired();
        }
    }
}