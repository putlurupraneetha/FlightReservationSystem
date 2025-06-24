using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationSystem.Models
{
    public class Flight
    {
        public int Id { get; set; }

        [Required]
        public string FlightNumber { get; set; }

        public int AirlineId { get; set; }
        public Airline Airline { get; set; }

        public int FromAirportId { get; set; }
        public Airport FromAirport { get; set; }

        public int ToAirportId { get; set; }
        public Airport ToAirport { get; set; }

        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }

        public int AvailableSeats { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        // ✅ Add this navigation property for EF relationship
        public ICollection<Booking> Bookings { get; set; }
    }
}
