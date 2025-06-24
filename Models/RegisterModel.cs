using System.ComponentModel.DataAnnotations;

namespace FlightReservationSystem.Models
{
    public class RegisterModel
{
    [Required]
    public string FullName { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }

     public string PhoneNumber { get; set; } 
}

}
