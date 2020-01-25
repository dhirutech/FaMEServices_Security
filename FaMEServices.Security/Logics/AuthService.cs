using FaMEServices.Security.Interfaces;
using FaMEServices.Security.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FaMEServices.Security.Logics
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _config;
        public AuthService(IConfiguration config)
        {
            _config = config;
        }
        public async Task<AuthToken> GetAccessToken(UserDetail user)
        {
            if (user == null || DateTimeOffset.Now >= DateTimeOffset.UtcNow.AddDays(120))
                return null;

            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var signingKey = Convert.FromBase64String(_config["Jwt:SigningSecret"]);
            var expiryDuration = int.Parse(_config["Jwt:ExpiryDuration"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = null,              // Not required as no third-party is involved
                Audience = null,            // Not required as no third-party is involved
                IssuedAt = DateTime.UtcNow,
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(expiryDuration),
                Subject = new ClaimsIdentity(new List<Claim> {
                        new Claim("userid", user.UserId.ToString()),
                        new Claim("role", user.Role)
                    }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(signingKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var jwtToken = jwtTokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            var token = jwtTokenHandler.WriteToken(jwtToken);
            var authToken = new AuthToken()
            {
                Token = token,
                Refreshtoken = Guid.NewGuid().ToString()
            };
            return authToken;
        }
    }
}
