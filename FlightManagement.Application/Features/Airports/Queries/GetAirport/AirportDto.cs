namespace FlightManagement.Application.Features.Airports
{
    public class AirportDto
    {
        public string Name { get; set; }
        public string IcaoCode { get; set; }
        public string IataCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}