using System.Linq;
using System.Threading.Tasks;
using FlightManagement.Core.Application.Contracts.Persistence;
using FlightManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlightManagement.Persistence.Repositories
{
    public class AirportRepository : BaseRepository<Airport>, IAirportRepository
    {
        public AirportRepository(FlightManagementDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Airport> GetByIcaoCodeAsync(string icao)
        {
            return await _dbContext.Airports.Where(q => q.IcaoCode == icao).FirstOrDefaultAsync();
        }

        public async Task<Airport> GetByIataCodeAsync(string iata)
        {
            return await _dbContext.Airports.Where(q => q.IcaoCode == iata).FirstOrDefaultAsync();
        }
    }
}