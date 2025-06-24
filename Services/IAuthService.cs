using FlightReservationSystem.DTOs;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace FlightReservationSystem.Interfaces
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterAsync(RegisterDTO registerDTO);
        Task<string> GenerateJwtToken(ApplicationUser user);
    }
}
