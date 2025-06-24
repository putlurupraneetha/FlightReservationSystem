using Microsoft.AspNetCore.Mvc;
using FlightReservationSystem.Interfaces;
using FlightReservationSystem.Repositories;
using FlightReservationSystem.DTOs;

namespace FlightReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly IPassengerRepository _passengerRepository;

        public PassengerController(IPassengerRepository passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPassengers()
        {
            var passengers = await _passengerRepository.GetAllPassengersAsync();
            return Ok(passengers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPassengerById(int id)
        {
            var passenger = await _passengerRepository.GetPassengerByIdAsync(id);
            if (passenger == null)
                return NotFound();

            return Ok(passenger);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePassenger(PassengerDTO passengerDTO)
        {
            var passenger = new Passenger
            {
                FirstName = passengerDTO.FirstName,
                LastName = passengerDTO.LastName,
                DateOfBirth = passengerDTO.DateOfBirth,
                PassportNumber = passengerDTO.PassportNumber
            };

            await _passengerRepository.AddPassengerAsync(passenger);
            return CreatedAtAction(nameof(GetPassengerById), new { id = passenger.Id }, passenger);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePassenger(int id, PassengerDTO passengerDTO)
        {
            var passenger = await _passengerRepository.GetPassengerByIdAsync(id);
            if (passenger == null)
                return NotFound();

            passenger.FirstName = passengerDTO.FirstName;
            passenger.LastName = passengerDTO.LastName;
            passenger.DateOfBirth = passengerDTO.DateOfBirth;
            passenger.PassportNumber = passengerDTO.PassportNumber;

            await _passengerRepository.UpdatePassengerAsync(passenger);
            return Ok(new { message = "Passenger updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassenger(int id)
        {
            var passenger = await _passengerRepository.GetPassengerByIdAsync(id);
            if (passenger == null)
                return NotFound();

            await _passengerRepository.DeletePassengerAsync(id);
            return Ok(new { message = "Passenger deleted successfully" });
        }
    }
}
