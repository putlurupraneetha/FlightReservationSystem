using FlightReservationSystem.DTOs;

namespace FlightReservationSystem.DTOs
{
    public class PassengerDTO
    {
        public int Id { get; set; }  
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PassportNumber { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }  
        public ICollection<BookingDTO> Bookings { get; set; }  
    }
}
