using FlightReservationSystem.Data;
using FlightReservationSystem.Models;
using FlightReservationSystem.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace FlightReservationSystem.Repositories
{
    public class PassengerRepository : IPassengerRepository
    {
        private readonly FlightReservationDbContext _context;

        public PassengerRepository(FlightReservationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Passenger>> GetAllPassengersAsync()
        {
            return await _context.Passengers.ToListAsync();
        }

        public async Task<Passenger> GetPassengerByIdAsync(int passengerId)
        {
            return await _context.Passengers.FindAsync(passengerId);
        }

        public async Task AddPassengerAsync(Passenger passenger)
        {
            await _context.Passengers.AddAsync(passenger);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePassengerAsync(Passenger passenger)
        {
            _context.Passengers.Update(passenger);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePassengerAsync(int passengerId)
        {
            var passenger = await GetPassengerByIdAsync(passengerId);
            if (passenger != null)
            {
                _context.Passengers.Remove(passenger);
                await _context.SaveChangesAsync();
            }
        }
    }
}
