using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlightManagement.Application.Features.Airports;
using FlightManagement.Application.Features.Airports.Commands.CreateAirport;
using FlightManagement.Application.Features.Airports.Queries.GetAirportsExport;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightManagement.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AirportsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AirportsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IList<AirportListDto>>> GetAirports()
        {
            IList<AirportListDto> airports = await _mediator.Send(new GetAirportsListQuery());
            return Ok(airports);
        }

        [HttpGet("{icao}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IList<AirportListDto>>> GetAirportByIcaoCode(string icao)
        {
            var query = new GetAirportByIcaoCodeQuery { IcaoCode = icao };
            AirportDto airport = await _mediator.Send(query);

            return Ok(airport);
        }

        [HttpPost]
        public async Task<ActionResult<CreateAirportCommandResponse>> Create([FromForm] CreateAirportCommand createAirportCommand)
        {
            CreateAirportCommandResponse response = await _mediator.Send(createAirportCommand);
            return Ok(response);
        }

        [HttpGet("export")]
        public async Task<FileResult> ExportAirports()
        {
            AirportExportFileDto exportFile = await _mediator.Send(new GetAirportsExportQuery());
            return File(exportFile.Data, exportFile.ContentType, exportFile.AirportExportFileName);
        }
    }
}