using FlightReservationSystem.Data;
using FlightReservationSystem.Models;
using FlightReservationSystem.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace FlightReservationSystem.Repositories
{
    public class AirportRepository : IAirportRepository
    {
        private readonly FlightReservationDbContext _context;

        public AirportRepository(FlightReservationDbContext context)
        {
            _context = context;
        }

        
        public async Task<Airport> GetAirportByIdAsync(int id)
        {
            return await _context.Airports.FindAsync(id);
        }

       
        public async Task<IEnumerable<Airport>> GetAllAirportsAsync()
        {
            return await _context.Airports.ToListAsync();
        }

      
        public async Task AddAirportAsync(Airport airport)
        {
            await _context.Airports.AddAsync(airport);
            await _context.SaveChangesAsync();
        }

        
        public async Task UpdateAirportAsync(Airport airport)
        {
            _context.Airports.Update(airport);
            await _context.SaveChangesAsync();
        }

       
        public async Task DeleteAirportAsync(int id)
        {
            var airport = await _context.Airports.FindAsync(id);
            if (airport != null)
            {
                _context.Airports.Remove(airport);
                await _context.SaveChangesAsync();
            }
        }
    }
}
