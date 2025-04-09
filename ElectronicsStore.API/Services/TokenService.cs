using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ElectronicsStore.API.Models;
using Microsoft.IdentityModel.Tokens;

namespace ElectronicsStore.API.Services
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("FullName", $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role, user.Role ?? "User") // ✅ Add Role claim
            };

            // Get JWT config values
            var keyString = _configuration["Jwt:Key"]
                            ?? throw new InvalidOperationException("JWT Key is missing in appsettings.json");

            var issuer = _configuration["Jwt:Issuer"]
                         ?? throw new InvalidOperationException("JWT Issuer is missing in appsettings.json");

            var audience = _configuration["Jwt:Audience"]
                           ?? throw new InvalidOperationException("JWT Audience is missing in appsettings.json");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
