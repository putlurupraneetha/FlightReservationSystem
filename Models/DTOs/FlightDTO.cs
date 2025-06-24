using FlightReservationSystem.DTOs;

namespace FlightReservationSystem.DTOs
{
    public class FlightDTO
    {
        public string FlightNumber { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public int FromAirportId { get; set; }
        public int ToAirportId { get; set; }
        public int AirlineId { get; set; }
        public int AvailableSeats { get; set; }
        public decimal Price { get; set; }
    }
}
