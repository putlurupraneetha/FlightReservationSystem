using FlightReservationSystem.Data;
using FlightReservationSystem.Models;
using FlightReservationSystem.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace FlightReservationSystem.Interfaces
{
   public interface IFlightRepository
{
    Task<Flight> GetFlightByIdAsync(int flightId);
    Task<IEnumerable<Flight>> GetFlightsByAirlineAsync(int airlineId);
    Task<IEnumerable<Flight>> GetAllFlightsAsync();
    Task AddFlightAsync(Flight flight);
    Task UpdateFlightAsync(Flight flight);
    Task DeleteFlightAsync(int flightId);
}

}
