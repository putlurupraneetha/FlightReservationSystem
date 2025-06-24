using FlightReservationSystem.Data;
using FlightReservationSystem.Models;
using FlightReservationSystem.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace FlightReservationSystem.Interfaces
{
   public interface IBookingPassengerRepository
{
    Task<BookingPassenger> GetBookingPassengerByIdAsync(int bookingPassengerId);
    Task<IEnumerable<BookingPassenger>> GetAllBookingPassengerByIdAsync(string bookingId);
  Task<IEnumerable<BookingPassenger>> GetPassengersByBookingAsync(int bookingId);
    Task AddBookingPassengerAsync(BookingPassenger bookingPassenger);
    Task UpdateBookingPassengerAsync(BookingPassenger bookingPassenger);
    Task DeleteBookingPassengerAsync(int bookingPassengerId);
}

}
