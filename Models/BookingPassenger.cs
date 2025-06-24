using System.ComponentModel.DataAnnotations;
using FlightReservationSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;
public class BookingPassenger
{
    [Key]
    public int Id { get; set; }

    [ForeignKey(nameof(Booking))]
    public int BookingId { get; set; }
    public Booking Booking { get; set; }

    [ForeignKey(nameof(Passenger))]
    public int PassengerId { get; set; }
    public Passenger Passenger { get; set; }

    public bool IsCheckedIn { get; set; }  // Add this back if still needed
}
