using MediatR;

namespace FlightManagement.Application.Features.Airports
{
    public class GetAirportByIcaoCodeQuery : IRequest<AirportDto>
    {
        public string IcaoCode { get; set; }
    }
}