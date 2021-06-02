using AutoMapper;
using FlightManagement.Application.Features.Airports;
using FlightManagement.Application.Features.Airports.Commands.CreateAirport;
using FlightManagement.Domain.Entities;

namespace FlightManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Airport, AirportListDto>().ReverseMap();
            CreateMap<Airport, AirportDto>().ReverseMap();
            CreateMap<Airport, CreateAirportCommand>().ReverseMap();
        }
    }
}