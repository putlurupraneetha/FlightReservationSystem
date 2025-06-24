using FlightReservationSystem.Data;
using FlightReservationSystem.Models;
using FlightReservationSystem.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightReservationSystem.Interfaces
{
   public interface IPassengerRepository
{
    Task<Passenger> GetPassengerByIdAsync(int passengerId);
    Task<IEnumerable<Passenger>> GetAllPassengersAsync();
    Task AddPassengerAsync(Passenger passenger);
    Task UpdatePassengerAsync(Passenger passenger);
    Task DeletePassengerAsync(int passengerId);
}

}
