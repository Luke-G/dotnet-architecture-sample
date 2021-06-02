using System.Threading.Tasks;
using FlightManagement.Domain.Entities;

namespace FlightManagement.Core.Application.Contracts.Persistence
{
    public interface IAirportRepository : IAsyncRepository<Airport>
    {
        Task<Airport> GetByIcaoCodeAsync(string icao);
        Task<Airport> GetByIataCodeAsync(string iata);
    }
}