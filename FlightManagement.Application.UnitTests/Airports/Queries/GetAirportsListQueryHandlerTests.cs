using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FlightManagement.Application.Features.Airports;
using FlightManagement.Application.Profiles;
using FlightManagement.Application.UnitTests.Mocks;
using FlightManagement.Core.Application.Contracts.Persistence;
using Moq;
using Shouldly;
using Xunit;

namespace FlightManagement.Application.UnitTests.Airports.Queries
{
    public class GetAirportsListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAirportRepository> _mockAirportRepository;

        public GetAirportsListQueryHandlerTests()
        {
            _mockAirportRepository = RepositoryMocks.GetAirportRepository();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            _mapper = configuration.CreateMapper();
        }

        [Fact]
        public async Task GetAirportsListTest()
        {
            var handler = new GetAirportsListQueryHandler(_mockAirportRepository.Object, _mapper);

            IList<AirportListDto> result = await handler.Handle(new GetAirportsListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<AirportListDto>>();
            result.Count.ShouldBe(2);
        }
    }
}