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
    public class AirlineController : ControllerBase
    {
        private readonly IAirlineRepository _airlineRepository;

        public AirlineController(IAirlineRepository airlineRepository)
        {
            _airlineRepository = airlineRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAirlines()
        {
            var airlines = await _airlineRepository.GetAllAirlinesAsync();
            return Ok(airlines);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAirlineById(int id)
        {
            var airline = await _airlineRepository.GetAirlineByIdAsync(id);
            if (airline == null)
                return NotFound();

            return Ok(airline);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAirline(AirlineDTO airlineDTO)
        {
            var airline = new Airline
            {
                Name = airlineDTO.AirlineName,
                Country = airlineDTO.Country,
                IATA = airlineDTO.IATA
            };

            await _airlineRepository.AddAirlineAsync(airline);
            return CreatedAtAction(nameof(GetAirlineById), new { id = airline.Id }, airline);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAirline(int id, AirlineDTO airlineDTO)
        {
            var airline = await _airlineRepository.GetAirlineByIdAsync(id);
            if (airline == null)
                return NotFound();

            airline.Name = airlineDTO.AirlineName;
            airline.Country = airlineDTO.Country;
            airline.IATA = airlineDTO.IATA;

            await _airlineRepository.UpdateAirlineAsync(airline);
            return Ok(new { message = "Airline updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAirline(int id)
        {
            var airline = await _airlineRepository.GetAirlineByIdAsync(id);
            if (airline == null)
                return NotFound();

            await _airlineRepository.DeleteAirlineAsync(id);
            return Ok(new { message = "Airline deleted successfully" });
        }
    }
}
