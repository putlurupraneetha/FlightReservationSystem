using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

public class ApplicationUser : IdentityUser
{
    public string ? FullName { get; set; }
    public string ? Address { get; set; }
    public required string  PhoneNumber { get; set; }


}
