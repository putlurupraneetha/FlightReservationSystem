using System.ComponentModel.DataAnnotations;
using FlightReservationSystem.Models;

public class Passenger
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; }
    public string PassportNumber { get; set; }
    public string Nationality { get; set; }
    public ICollection<Booking> Bookings { get; set; }
    public ICollection<BookingPassenger> BookingPassengers { get; set; }
}
