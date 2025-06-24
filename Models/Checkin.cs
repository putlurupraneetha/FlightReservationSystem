using System.ComponentModel.DataAnnotations;
using FlightReservationSystem.Models;

public class Checkin
{
    public int Id { get; set; }
    public int BookingId { get; set; }
    public Booking Booking { get; set; }
    public DateTime CheckinDate { get; set; }
    public string SeatNumber { get; set; }
    public string Gate { get; set; }
    public bool IsCheckedIn { get; set; }
}
