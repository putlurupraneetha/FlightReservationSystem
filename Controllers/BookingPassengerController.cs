using Microsoft.AspNetCore.Mvc;
using FlightReservationSystem.DTOs;
using FlightReservationSystem.Interfaces;
using FlightReservationSystem.Models;
using FlightReservationSystem.Services; 
using FlightReservationSystem.Repositories;


namespace FlightReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingPassengerController : ControllerBase
    {
        private readonly IBookingPassengerRepository _bookingPassengerRepository;

        public BookingPassengerController(IBookingPassengerRepository bookingPassengerRepository)
        {
            _bookingPassengerRepository = bookingPassengerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBookingPassengers(string bookingId)
        {
            var bookingPassengers = await _bookingPassengerRepository.GetAllBookingPassengerByIdAsync(bookingId);
            return Ok(bookingPassengers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingPassengerById(int id)
        {
            var bookingPassenger = await _bookingPassengerRepository.GetBookingPassengerByIdAsync(id);
            if (bookingPassenger == null)
                return NotFound();

            return Ok(bookingPassenger);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBookingPassenger(BookingPassengerDTO bookingPassengerDTO)
        {
            var bookingPassenger = new BookingPassenger
            {
                BookingId = bookingPassengerDTO.BookingId,
                PassengerId = bookingPassengerDTO.PassengerId
            };

            await _bookingPassengerRepository.AddBookingPassengerAsync(bookingPassenger);
            return CreatedAtAction(nameof(GetBookingPassengerById), new { id = bookingPassenger.Id }, bookingPassenger);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBookingPassenger(int id, BookingPassengerDTO bookingPassengerDTO)
        {
            var bookingPassenger = await _bookingPassengerRepository.GetBookingPassengerByIdAsync(id);
            if (bookingPassenger == null)
                return NotFound();

            bookingPassenger.BookingId = bookingPassengerDTO.BookingId;
            bookingPassenger.PassengerId = bookingPassengerDTO.PassengerId;

            await _bookingPassengerRepository.UpdateBookingPassengerAsync(bookingPassenger);
            return Ok(new { message = "Booking Passenger updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingPassenger(int id)
        {
            var bookingPassenger = await _bookingPassengerRepository.GetBookingPassengerByIdAsync(id);
            if (bookingPassenger == null)
                return NotFound();

            await _bookingPassengerRepository.DeleteBookingPassengerAsync(id);
            return Ok(new { message = "Booking Passenger deleted successfully" });
        }
    }
}
