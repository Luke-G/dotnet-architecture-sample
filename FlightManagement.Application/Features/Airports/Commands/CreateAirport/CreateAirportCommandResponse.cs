using FlightManagement.Application.Responses;

namespace FlightManagement.Application.Features.Airports.Commands.CreateAirport
{
    public class CreateAirportCommandResponse : BaseResponse
    {
        public CreateAirportCommandResponse() : base()
        {

        }

        public AirportDto Airport { get; set; }
    }
}