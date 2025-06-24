using FlightReservationSystem.Data;
using FlightReservationSystem.Models;
using FlightReservationSystem.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using FlightReservationSystem.Repositories;
using System.Threading.Tasks;


namespace FlightReservationSystem.Repositories
{
    public class BookingPassengerRepository : IBookingPassengerRepository
    {
        private readonly FlightReservationDbContext _context;

        public BookingPassengerRepository(FlightReservationDbContext context)
        {
            _context = context;
        }

        public async Task<BookingPassenger> GetBookingPassengerByIdAsync(int bookingPassengerId)
        {
            return await _context.BookingPassengers.FindAsync(bookingPassengerId);
        }
            public async Task<IEnumerable<BookingPassenger>> GetAllBookingPassengerByIdAsync(string bookingId)
        {
            var passengers = await _context.BookingPassengers
                                            .Where(bp => bp.BookingId.ToString() == bookingId)  // Convert BookingId to string
                                            .ToListAsync();
            return passengers;
        }


        public async Task<IEnumerable<BookingPassenger>> GetPassengersByBookingAsync(int bookingId)
        {
            return await _context.BookingPassengers
                                 .Where(bp => bp.BookingId == bookingId)
                                 .ToListAsync();
        }

        public async Task AddBookingPassengerAsync(BookingPassenger bookingPassenger)
        {
            await _context.BookingPassengers.AddAsync(bookingPassenger);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBookingPassengerAsync(BookingPassenger bookingPassenger)
        {
            _context.BookingPassengers.Update(bookingPassenger);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookingPassengerAsync(int bookingPassengerId)
        {
            var passenger = await GetBookingPassengerByIdAsync(bookingPassengerId);
            if (passenger != null)
            {
                _context.BookingPassengers.Remove(passenger);
                await _context.SaveChangesAsync();
            }
        }
    }
}
