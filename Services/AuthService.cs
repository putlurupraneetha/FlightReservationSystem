using FlightReservationSystem.DTOs;
using FlightReservationSystem.Interfaces;
using FlightReservationSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        // Register a new user
        public async Task<IdentityResult> RegisterAsync(RegisterDTO registerDTO)
        {
            var user = new ApplicationUser
            {
                UserName = registerDTO.Username,
                Email = registerDTO.Email,
                FullName = registerDTO.Username,
                Address = registerDTO.Address,
                PhoneNumber = registerDTO.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, registerDTO.Password);
            return result;
        }

        // Generate JWT token
        public async Task<string> GenerateJwtToken(ApplicationUser user)
{
    if (user == null)
        throw new ArgumentNullException(nameof(user));

    // Ensure properties are not null
    var claims = new[]
    {
        new Claim(ClaimTypes.NameIdentifier, user.Id),
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim(ClaimTypes.Email, user.Email ?? string.Empty),  // Add null check for Email
        new Claim("FullName", user.FullName ?? "Unknown")          // Add default if FullName is null
    };

    // Use the correct configuration key path
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    var token = new JwtSecurityToken(
        issuer: _configuration["Jwt:Issuer"],
        audience: _configuration["Jwt:Audience"],
        claims: claims,
        expires: DateTime.Now.AddHours(1),
        signingCredentials: creds
    );

    return new JwtSecurityTokenHandler().WriteToken(token);
}


    }
}
