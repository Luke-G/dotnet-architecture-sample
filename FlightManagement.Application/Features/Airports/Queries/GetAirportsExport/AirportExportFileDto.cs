namespace FlightManagement.Application.Features.Airports.Queries.GetAirportsExport
{
    public class AirportExportFileDto
    {
        public string AirportExportFileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
    }
}