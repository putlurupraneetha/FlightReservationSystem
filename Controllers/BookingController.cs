using Microsoft.AspNetCore.Mvc;
using FlightReservationSystem.DTOs;
using FlightReservationSystem.Interfaces;
using System.Threading.Tasks;

namespace FlightReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings = await _bookingRepository.GetAllBookingsAsync();
            return Ok(bookings);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var booking = await _bookingRepository.GetBookingByIdAsync(id);
            if (booking == null)
                return NotFound();

            return Ok(booking);
        }

       
        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] BookingDTO bookingDTO)
        {
            await _bookingRepository.AddBookingAsync(bookingDTO);
            return Ok(new { message = "Booking created successfully" });
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking(int id, [FromBody] BookingDTO bookingDTO)
        {
            var existingBooking = await _bookingRepository.GetBookingByIdAsync(id);
            if (existingBooking == null)
                return NotFound();

            await _bookingRepository.UpdateBookingAsync(id, bookingDTO);
            return Ok(new { message = "Booking updated successfully" });
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var existingBooking = await _bookingRepository.GetBookingByIdAsync(id);
            if (existingBooking == null)
                return NotFound();

            await _bookingRepository.DeleteBookingAsync(id);
            return Ok(new { message = "Booking deleted successfully" });
        }
    }
}
