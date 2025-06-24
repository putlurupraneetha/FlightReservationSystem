using FlightReservationSystem.Data;
using FlightReservationSystem.Models;
using FlightReservationSystem.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using FlightReservationSystem.Services;



namespace FlightReservationSystem.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenService;

        public AuthenticationRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<string> RegisterAsync(RegisterModel model)
        {
            var user = new ApplicationUser 
            { 
                UserName = model.Email, 
                Email = model.Email, 
                FullName = model.FullName, 
                PhoneNumber = model.PhoneNumber  
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return "Registration Successful";
            }

            return "Registration Failed: " + string.Join(", ", result.Errors.Select(e => e.Description));
        }

        public async Task<string> LoginAsync(LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return "User does not exist";
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (result.Succeeded)
            {
                var token = await _tokenService.GenerateJwtToken(user);
                return token;
            }

            return "Invalid credentials or account is locked";
        }
    }
}
