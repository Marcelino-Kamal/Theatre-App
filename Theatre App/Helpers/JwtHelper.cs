using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Theatre_App.DTO;
using Theatre_App.Models;

namespace Theatre_App.Helpers
{
    public class JwtHelper
    {
        public static JwtTokenResult GenerateToken(Users user)
        {
            var secretKey = Environment.GetEnvironmentVariable("JWT_SECRET_KEY");
            var issuer = Environment.GetEnvironmentVariable("JWT_ISSUER");
            var audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE");
            var expiryMinutes = int.Parse(Environment.GetEnvironmentVariable("JWT_EXPIRY") ?? "60");

            var expiryTime = DateTime.UtcNow.AddMinutes(expiryMinutes);

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.PhoneNumber),
                new Claim("UserId", user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.Name)
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: expiryTime,
                signingCredentials: credentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new JwtTokenResult
            {
                Token = tokenString,
                Expiry = expiryTime
            };
        }

        public static List<Claim>? ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secretKey = Environment.GetEnvironmentVariable("JWT_SECRET_KEY");
            var issuer = Environment.GetEnvironmentVariable("JWT_ISSUER");
            var audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            try
            {
                var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key
                }, out _);

                return principal.Claims.ToList();
            }
            catch
            {
                return null;
            }
        }
    }
}
