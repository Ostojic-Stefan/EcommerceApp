using api.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace api.Services
{
    public class AuthService
    {
        private readonly IConfiguration _config;
        private List<Claim> claims = new();

        public AuthService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(User user, Action<List<Claim>>? additionalClaims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]!);

            claims.Add(new Claim(JwtRegisteredClaimNames.NameId, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));

            // TODO: add claims from the DB

            additionalClaims?.Invoke(claims);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(30),
                Issuer = _config["JwtSettings:Issuer"],
                Audience = _config["JwtSettings:Audience"],
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);
            return jwt;
        }
    }
}
