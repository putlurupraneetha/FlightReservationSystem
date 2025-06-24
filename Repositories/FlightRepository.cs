using FlightReservationSystem.Data;
using FlightReservationSystem.Interfaces;
using FlightReservationSystem.Models;
using FlightReservationSystem.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace FlightReservationSystem.Repositories
{
    public class FlightRepository : IFlightRepository
{
    private readonly FlightReservationDbContext _context;

    public FlightRepository(FlightReservationDbContext context)
    {
        _context = context;
    }

    public async Task<Flight> GetFlightByIdAsync(int flightId)
    {
        return await _context.Flights
            .Include(f => f.Airline)
            .Include(f => f.FromAirport)
            .Include(f => f.ToAirport)
            .FirstOrDefaultAsync(f => f.Id == flightId);
    }

    public async Task<IEnumerable<Flight>> GetFlightsByAirlineAsync(int airlineId)
    {
        return await _context.Flights
            .Include(f => f.Airline)
            .Include(f => f.FromAirport)
            .Include(f => f.ToAirport)
            .Where(f => f.AirlineId == airlineId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Flight>> GetAllFlightsAsync()
    {
        return await _context.Flights
            .Include(f => f.Airline)
            .Include(f => f.FromAirport)
            .Include(f => f.ToAirport)
            .ToListAsync();
    }

    public async Task AddFlightAsync(Flight flight)
    {
        await _context.Flights.AddAsync(flight);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateFlightAsync(Flight flight)
    {
        _context.Flights.Update(flight);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteFlightAsync(int flightId)
    {
        var flight = await GetFlightByIdAsync(flightId);
        if (flight != null)
        {
            _context.Flights.Remove(flight);
            await _context.SaveChangesAsync();
        }
    }
}


}