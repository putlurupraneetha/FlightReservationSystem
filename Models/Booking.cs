using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FlightReservationSystem.Models;

namespace FlightReservationSystem.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public int FlightId { get; set; }
        public Flight Flight { get; set; }

        public int PassengerId { get; set; }
        public Passenger Passenger { get; set; }

         public DateTime? DepartureTime { get; set; }

        public DateTime BookingDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        // Navigation property for Checkins
        public ICollection<Checkin> Checkins { get; set; }
        public ICollection<BookingPassenger> BookingPassengers { get; set; }
        
       
    }
}
