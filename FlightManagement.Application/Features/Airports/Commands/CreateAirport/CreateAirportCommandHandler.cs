using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FlightManagement.Application.Contracts.Infrastructure;
using FlightManagement.Application.Models;
using FlightManagement.Core.Application.Contracts.Persistence;
using FlightManagement.Domain.Entities;
using FluentValidation.Results;
using MediatR;

namespace FlightManagement.Application.Features.Airports.Commands.CreateAirport
{
    public class CreateAirportCommandHandler : IRequestHandler<CreateAirportCommand, CreateAirportCommandResponse>
    {
        private readonly IAirportRepository _airportRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public CreateAirportCommandHandler(IAirportRepository airportRepository, IMapper mapper, IEmailService emailService)
        {
            _airportRepository = airportRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<CreateAirportCommandResponse> Handle(CreateAirportCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateAirportCommandResponse();
            var validator = new CreateAirportCommandValidator();
            ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Any())
            {
                response.Success = false;

                foreach (var error in validationResult.Errors)
                    response.ValidationErrors.Add(error.ErrorMessage);

                return response;
            }

            Airport airport = await _airportRepository.AddAsync(_mapper.Map<Airport>(request));
            response.Airport = _mapper.Map<AirportDto>(airport);

            _ = await _emailService.SendEmail(new Email
            {
                To = "admin@volanta.dev",
                Subject = "Airport Created",
                Body = $"A new airport was created. ICAO: {airport.IcaoCode}"
            });

            return response;
        }
    }
}