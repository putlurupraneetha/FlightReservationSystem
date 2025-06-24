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
    public class AirportController : ControllerBase
    {
        private readonly IAirportRepository _airportRepository;

        public AirportController(IAirportRepository airportRepository)
        {
            _airportRepository = airportRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAirports()
        {
            var airports = await _airportRepository.GetAllAirportsAsync();
            return Ok(airports);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAirportById(int id)
        {
            var airport = await _airportRepository.GetAirportByIdAsync(id);
            if (airport == null)
                return NotFound();

            return Ok(airport);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAirport(AirportDTO airportDTO)
        {
            var airport = new Airport
            {
                Name = airportDTO.Name,
                Location = airportDTO.Location,
                IATA = airportDTO.IATA,
                Country=airportDTO.Country
            };

            await _airportRepository.AddAirportAsync(airport);
            return CreatedAtAction(nameof(GetAirportById), new { id = airport.Id }, airport);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAirport(int id, AirportDTO airportDTO)
        {
            var airport = await _airportRepository.GetAirportByIdAsync(id);
            if (airport == null)
                return NotFound();

            airport.Name = airportDTO.Name;
            airport.Location = airportDTO.Location;
            airport.IATA = airportDTO.IATA;

            await _airportRepository.UpdateAirportAsync(airport);
            return Ok(new { message = "Airport updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAirport(int id)
        {
            var airport = await _airportRepository.GetAirportByIdAsync(id);
            if (airport == null)
                return NotFound();

            await _airportRepository.DeleteAirportAsync(id);
            return Ok(new { message = "Airport deleted successfully" });
        }
    }
}
