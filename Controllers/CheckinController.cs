using Microsoft.AspNetCore.Mvc;
using FlightReservationSystem.DTOs;
using FlightReservationSystem.Interfaces;
using FlightReservationSystem.Models;
using System.Threading.Tasks;

namespace FlightReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckInController : ControllerBase
    {
        private readonly ICheckinRepository _checkInRepository;

        public CheckInController(ICheckinRepository checkInRepository)
        {
            _checkInRepository = checkInRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCheckIns()
        {
            var checkIns = await _checkInRepository.GetAllCheckinsAsync();
            return Ok(checkIns);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCheckInById(int id)
        {
            var checkIn = await _checkInRepository.GetCheckinByIdAsync(id);
            if (checkIn == null)
                return NotFound();

            return Ok(checkIn);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCheckIn([FromBody] CheckinDTO checkInDTO)
        {
            var checkIn = new Checkin
            {
                BookingId = checkInDTO.BookingId,
                CheckinDate = checkInDTO.CheckinTime,
                Gate = checkInDTO.Gate,
                SeatNumber = checkInDTO.Seat,
                IsCheckedIn = true 
            };

            await _checkInRepository.AddCheckinAsync(checkIn);
            return CreatedAtAction(nameof(GetCheckInById), new { id = checkIn.Id }, checkIn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCheckIn(int id, [FromBody] CheckinDTO checkInDTO)
        {
            var checkIn = await _checkInRepository.GetCheckinByIdAsync(id);
            if (checkIn == null)
                return NotFound();

            checkIn.BookingId = checkInDTO.BookingId;
            checkIn.CheckinDate = checkInDTO.CheckinTime;
            checkIn.Gate = checkInDTO.Gate;
            checkIn.SeatNumber = checkInDTO.Seat;
            checkIn.IsCheckedIn = true;

            await _checkInRepository.UpdateCheckinAsync(checkIn);
            return Ok(new { message = "Check-In updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCheckIn(int id)
        {
            var checkIn = await _checkInRepository.GetCheckinByIdAsync(id);
            if (checkIn == null)
                return NotFound();

            await _checkInRepository.DeleteCheckinAsync(id);
            return Ok(new { message = "Check-In deleted successfully" });
        }
    }
}
