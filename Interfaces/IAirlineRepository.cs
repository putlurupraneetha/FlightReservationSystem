using FlightReservationSystem.Data;
using FlightReservationSystem.Models;
using FlightReservationSystem.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightReservationSystem.Interfaces
{
    public interface IAirlineRepository
{
    Task<Airline> GetAirlineByIdAsync(int airlineId);
    Task<IEnumerable<Airline>> GetAllAirlinesAsync();
    Task AddAirlineAsync(Airline airline);
    Task UpdateAirlineAsync(Airline airline);
    Task DeleteAirlineAsync(int airlineId);
}

}