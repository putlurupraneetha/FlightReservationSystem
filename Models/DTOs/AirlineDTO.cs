using FlightReservationSystem.Models; 
 
namespace FlightReservationSystem.DTOs
{
    public class AirlineDTO
    {
        public string AirlineName { get; set; }
        public string IATA { get; set; }
        public string Country { get; set; }
    }
}
