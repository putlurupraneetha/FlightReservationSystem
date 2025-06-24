using FlightReservationSystem.Data;
using FlightReservationSystem.Models;
using FlightReservationSystem.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace FlightReservationSystem.Repositories
{
    public class CheckinRepository : ICheckinRepository
{
    private readonly FlightReservationDbContext _context;

    public CheckinRepository(FlightReservationDbContext context)
    {
        _context = context;
    }

    public async Task<Checkin> GetCheckinByIdAsync(int checkinId)
    {
        return await _context.Checkins.FindAsync(checkinId);
    }

     
    public async Task<IEnumerable<Checkin>> GetAllCheckinsAsync()
    {
        return await _context.Checkins.ToListAsync();
    }

    public async Task<IEnumerable<Checkin>> GetCheckinsByBookingAsync(int bookingId)
    {
        return await _context.Checkins
                             .Where(c => c.BookingId == bookingId)
                             .ToListAsync();
    }

    public async Task AddCheckinAsync(Checkin checkin)
    {
        await _context.Checkins.AddAsync(checkin);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCheckinAsync(Checkin checkin)
    {
        _context.Checkins.Update(checkin);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCheckinAsync(int checkinId)
    {
        var checkin = await GetCheckinByIdAsync(checkinId);
        if (checkin != null)
        {
            _context.Checkins.Remove(checkin);
            await _context.SaveChangesAsync();
        }
    }
}

}