using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FlightManagement.Core.Application.Contracts.Persistence;
using MediatR;

namespace FlightManagement.Application.Features.Airports.Queries.GetAirportsExport
{
    public class GetAirportsExportQueryHandler : IRequestHandler<GetAirportsExportQuery, AirportExportFileDto>
    {
        private readonly IAirportRepository _airportRepository;
        private readonly IMapper _mapper;

        public GetAirportsExportQueryHandler(IAirportRepository airportRepository, IMapper mapper)
        {
            _airportRepository = airportRepository;
            _mapper = mapper;
        }

        public async Task<AirportExportFileDto> Handle(GetAirportsExportQuery request, CancellationToken cancellationToken)
        {
            var allAirports = _mapper.Map<IList<AirportDto>>(await _airportRepository.ListAllAsync());
            string json = JsonSerializer.Serialize(allAirports);

            var exportFileDto = new AirportExportFileDto
            {
                AirportExportFileName = $"Export {DateTime.UtcNow.ToShortDateString()}.json",
                ContentType = "application/json",
                Data = Encoding.UTF8.GetBytes(json)
            };

            return exportFileDto;
        }
    }
}