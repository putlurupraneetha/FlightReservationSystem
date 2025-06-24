using FlightReservationSystem.Data;
using FlightReservationSystem.Models;
using FlightReservationSystem.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightReservationSystem.Repositories
{
    public class AirlineRepository : IAirlineRepository
    {
        private readonly FlightReservationDbContext _context;

        public AirlineRepository(FlightReservationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Airline>> GetAllAirlinesAsync()
        {
            return await _context.Airlines.ToListAsync();
        }

        public async Task<Airline> GetAirlineByIdAsync(int airlineId)
        {
            return await _context.Airlines.FindAsync(airlineId);
        }

        public async Task AddAirlineAsync(Airline airline)
        {
            await _context.Airlines.AddAsync(airline);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAirlineAsync(Airline airline)
        {
            _context.Airlines.Update(airline);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAirlineAsync(int airlineId)
        {
            var airline = await GetAirlineByIdAsync(airlineId);
            if (airline != null)
            {
                _context.Airlines.Remove(airline);
                await _context.SaveChangesAsync();
            }
        }
    }
}
