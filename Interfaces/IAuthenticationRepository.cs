using FlightReservationSystem.Models;

namespace FlightReservationSystem.Interfaces{
    public interface IAuthenticationRepository
{
    Task<string> LoginAsync(LoginModel model);
    Task<string> RegisterAsync(RegisterModel model);
}

}