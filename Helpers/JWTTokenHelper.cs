﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace TheatreApp.Helpers
{
  
    public static class JwtTokenHelper
    {
        public static string GenerateToken(string phoneNumber, string role = "User")
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, phoneNumber),
            new Claim(ClaimTypes.Role, role)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("TheatreAppSecretKeyForJWTTokenGen"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "TheatreApp",
                audience: "TheatreAppClient",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}
