using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FlightManagement.Application.Features.Airports;
using FlightManagement.API.IntegrationTests.Base;
using Newtonsoft.Json;
using Xunit;

namespace FlightManagement.API.IntegrationTests.Controllers
{
    public class AirportControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public AirportControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsSuccessResult()
        {
            HttpClient client = _factory.GetAnonymousClient();
            HttpResponseMessage response = await client.GetAsync("/api/v1/airports");

            response.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeObject<IList<AirportListDto>>(await response.Content.ReadAsStringAsync());

            Assert.IsType<List<AirportListDto>>(result);
            Assert.NotEmpty(result);
        }
    }
}