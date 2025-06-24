using FlightReservationSystem.DTOs;

namespace FlightReservationSystem.DTOs
{
    public class PaymentDTO
    {
        public int BookingId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool IsSuccessful { get; set; }
    }
}

