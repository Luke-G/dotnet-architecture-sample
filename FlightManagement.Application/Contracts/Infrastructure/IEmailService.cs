using System.Threading.Tasks;
using FlightManagement.Application.Models;

namespace FlightManagement.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}