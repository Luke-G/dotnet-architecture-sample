using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FlightManagement.Application.Exceptions;
using FlightManagement.Core.Application.Contracts.Persistence;
using FlightManagement.Domain.Entities;
using MediatR;

namespace FlightManagement.Application.Features.Airports
{
    public class GetAirportByIcaoCodeQueryHandler : IRequestHandler<GetAirportByIcaoCodeQuery, AirportDto>
    {
        private readonly IAirportRepository _airportRepository;
        private readonly IMapper _mapper;

        public GetAirportByIcaoCodeQueryHandler(IAirportRepository airportRepository, IMapper mapper)
        {
            _airportRepository = airportRepository;
            _mapper = mapper;
        }

        public async Task<AirportDto> Handle(GetAirportByIcaoCodeQuery request, CancellationToken cancellationToken)
        {
            Airport airport = await _airportRepository.GetByIcaoCodeAsync(request.IcaoCode);

            if (airport == null)
                throw new NotFoundException();

            return _mapper.Map<AirportDto>(airport);
        }
    }
}