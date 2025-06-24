using FlightReservationSystem.Data;
using FlightReservationSystem.Models;
using FlightReservationSystem.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace FlightReservationSystem.Interfaces
{
public interface ICheckinRepository
{
    Task<Checkin> GetCheckinByIdAsync(int checkinId);
    Task<IEnumerable<Checkin>> GetCheckinsByBookingAsync(int bookingId);
    Task AddCheckinAsync(Checkin checkin);
    Task UpdateCheckinAsync(Checkin checkin);
    Task DeleteCheckinAsync(int checkinId);
    Task<IEnumerable<Checkin>> GetAllCheckinsAsync();

}
}
