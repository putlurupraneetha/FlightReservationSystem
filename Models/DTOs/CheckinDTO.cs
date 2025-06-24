using FlightReservationSystem.DTOs;

namespace FlightReservationSystem.DTOs
{
    public class CheckinDTO
    {
        public int BookingId { get; set; }
        public int PassengerId { get; set; }
        public DateTime CheckinTime { get; set; }
        public string Gate { get; set; }
        public string Seat { get; set; }
    }
}
