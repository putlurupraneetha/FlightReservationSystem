using FlightReservationSystem.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightReservationSystem.Interfaces
{
    public interface IBookingRepository
    {
        Task<BookingDTO> GetBookingByIdAsync(int bookingId);
        Task<IEnumerable<BookingDTO>> GetAllBookingsAsync();
        Task<IEnumerable<BookingDTO>> GetBookingsByCustomerAsync(int customerId);
        Task AddBookingAsync(BookingDTO bookingDTO);
        Task UpdateBookingAsync(int bookingId, BookingDTO bookingDTO);
        Task DeleteBookingAsync(int bookingId);
    }
}
