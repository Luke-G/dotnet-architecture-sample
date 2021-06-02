using System.Collections.Generic;
using FlightManagement.Domain.Entities;
using MediatR;

namespace FlightManagement.Application.Features.Airports
{
    public class GetAirportsListQuery : IRequest<IList<AirportListDto>>
    {

    }
}