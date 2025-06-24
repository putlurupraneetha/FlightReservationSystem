using System.ComponentModel.DataAnnotations;
using FlightReservationSystem.Models;

public class Payment
{
    public int Id { get; set; }
    public int BookingId { get; set; }
    public Booking Booking { get; set; }
    public decimal Amount { get; set; }
    public string PaymentMethod { get; set; } // Credit Card, PayPal, etc.
    public DateTime PaymentDate { get; set; }
    public bool IsSuccessful { get; set; }
}
