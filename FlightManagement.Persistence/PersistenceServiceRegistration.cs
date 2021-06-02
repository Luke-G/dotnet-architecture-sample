using FlightManagement.Core.Application.Contracts.Persistence;
using FlightManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlightManagement.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<FlightManagementDbContext>(options => options.UseNpgsql(configuration.GetValue<string>("ConnectionStrings:Database")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IAirportRepository, AirportRepository>();

            return services;
        }
    }
}