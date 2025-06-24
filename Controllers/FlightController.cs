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
    public class FlightController : ControllerBase
    {
        private readonly IFlightRepository _flightRepository;

        public FlightController(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFlights()
        {
            var flights = await _flightRepository.GetAllFlightsAsync();
            return Ok(flights);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFlightById(int id)
        {
            var flight = await _flightRepository.GetFlightByIdAsync(id);
            if (flight == null)
                return NotFound(new { message = "Flight not found" });

            return Ok(flight);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFlight([FromBody] FlightDTO flightDTO)
        {
            var flight = new Flight
            {
                FlightNumber = flightDTO.FlightNumber,
                AirlineId = flightDTO.AirlineId,
                FromAirportId = flightDTO.FromAirportId,
                ToAirportId = flightDTO.ToAirportId,
                DepartureTime = flightDTO.DepartureTime,
                ArrivalTime = flightDTO.ArrivalTime,
                AvailableSeats = flightDTO.AvailableSeats,
                Price = flightDTO.Price
            };

            await _flightRepository.AddFlightAsync(flight);
            return CreatedAtAction(nameof(GetFlightById), new { id = flight.Id }, flight);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFlight(int id, [FromBody] FlightDTO flightDTO)
        {
            var flight = await _flightRepository.GetFlightByIdAsync(id);
            if (flight == null)
                return NotFound(new { message = "Flight not found" });

            flight.FlightNumber = flightDTO.FlightNumber;
            flight.AirlineId = flightDTO.AirlineId;
            flight.FromAirportId = flightDTO.FromAirportId;
            flight.ToAirportId = flightDTO.ToAirportId;
            flight.DepartureTime = flightDTO.DepartureTime;
            flight.ArrivalTime = flightDTO.ArrivalTime;
            flight.AvailableSeats = flightDTO.AvailableSeats;
            flight.Price = flightDTO.Price;

            await _flightRepository.UpdateFlightAsync(flight);
            return Ok(new { message = "Flight updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            var flight = await _flightRepository.GetFlightByIdAsync(id);
            if (flight == null)
                return NotFound(new { message = "Flight not found" });

            await _flightRepository.DeleteFlightAsync(id);
            return Ok(new { message = "Flight deleted successfully" });
        }
    }
}