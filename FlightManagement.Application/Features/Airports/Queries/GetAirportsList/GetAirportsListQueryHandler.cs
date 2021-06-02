using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FlightManagement.Core.Application.Contracts.Persistence;
using FlightManagement.Domain.Entities;
using MediatR;

namespace FlightManagement.Application.Features.Airports
{
    public class GetAirportsListQueryHandler : IRequestHandler<GetAirportsListQuery, IList<AirportListDto>>
    {
        private readonly IAirportRepository _airportRepository;
        private readonly IMapper _mapper;

        public GetAirportsListQueryHandler(IAirportRepository airportRepository, IMapper mapper)
        {
            _airportRepository = airportRepository;
            _mapper = mapper;
        }

        public async Task<IList<AirportListDto>> Handle(GetAirportsListQuery request, CancellationToken cancellationToken = new())
        {
            IOrderedEnumerable<Airport> allAirports = (await _airportRepository.ListAllAsync()).OrderBy(q => q.Name);
            return _mapper.Map<IList<AirportListDto>>(allAirports);
        }
    }
}