using FlightReservationSystem.Models;

namespace FlightReservationSystem.Services
{
    public interface ITokenService
    {
        //string CreateToken(ApplicationUser user);
        Task<string> GenerateJwtToken(ApplicationUser user);

    }
}
