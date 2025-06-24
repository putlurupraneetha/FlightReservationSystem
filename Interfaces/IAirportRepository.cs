using FlightReservationSystem.Data;
using FlightReservationSystem.Models;
using FlightReservationSystem.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightReservationSystem.Interfaces
{
    public interface IAirportRepository
{
    Task<Airport> GetAirportByIdAsync(int id);
    Task<IEnumerable<Airport>> GetAllAirportsAsync();
    Task AddAirportAsync(Airport airport);
    Task UpdateAirportAsync(Airport airport);
    Task DeleteAirportAsync(int id);
}
}

