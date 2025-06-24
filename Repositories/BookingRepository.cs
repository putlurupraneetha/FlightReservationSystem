using FlightReservationSystem.Data;
using FlightReservationSystem.DTOs;
using FlightReservationSystem.Interfaces;
using FlightReservationSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightReservationSystem.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly FlightReservationDbContext _context;

        public BookingRepository(FlightReservationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BookingDTO>> GetAllBookingsAsync()
        {
            return await _context.Bookings
                .Include(b => b.Flight)
                .Include(b => b.Passenger)
                .Select(b => new BookingDTO
                {
                    FlightId = b.FlightId,
                    PassengerId = b.PassengerId,
                    BookingDate = b.BookingDate
                })
                .ToListAsync();
        }

        public async Task<BookingDTO> GetBookingByIdAsync(int bookingId)
        {
            var booking = await _context.Bookings
                .Include(b => b.Flight)
                .Include(b => b.Passenger)
                .FirstOrDefaultAsync(b => b.Id == bookingId);

            if (booking == null) return null;

            return new BookingDTO
            {
                FlightId = booking.FlightId,
                PassengerId = booking.PassengerId,
                BookingDate = booking.BookingDate
            };
        }

        public async Task<IEnumerable<BookingDTO>> GetBookingsByCustomerAsync(int customerId)
        {
            return await _context.Bookings
                .Include(b => b.Flight)
                .Include(b => b.Passenger)
                .Where(b => b.PassengerId == customerId)
                .Select(b => new BookingDTO
                {
                    FlightId = b.FlightId,
                    PassengerId = b.PassengerId,
                    BookingDate = b.BookingDate
                })
                .ToListAsync();
        }

        public async Task AddBookingAsync(BookingDTO bookingDTO)
        {
            var booking = new Booking
            {
                FlightId = bookingDTO.FlightId,
                PassengerId = bookingDTO.PassengerId,
                BookingDate = bookingDTO.BookingDate
            };

            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBookingAsync(int bookingId, BookingDTO bookingDTO)
        {
            var booking = await _context.Bookings.FindAsync(bookingId);
            if (booking == null) return;

            booking.FlightId = bookingDTO.FlightId;
            booking.PassengerId = bookingDTO.PassengerId;
            booking.BookingDate = bookingDTO.BookingDate;

            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookingAsync(int bookingId)
        {
            var booking = await _context.Bookings.FindAsync(bookingId);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
        }
    }
}
