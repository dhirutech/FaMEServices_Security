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
            if (user == null || DateTimeOffset.Now >= DateTimeOffset.UtcNow.AddDays(120.0))
                return (AuthToken)null;

            JwtSecurityTokenHandler securityTokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Convert.FromBase64String(this._config["Jwt:SigningSecret"]);
            int num = int.Parse(this._config["Jwt:ExpiryDuration"]);
            string str = securityTokenHandler.WriteToken((SecurityToken)securityTokenHandler.CreateJwtSecurityToken(new SecurityTokenDescriptor()
            {
                Issuer = (string)null,
                Audience = (string)null,
                IssuedAt = new DateTime?(DateTime.UtcNow),
                NotBefore = new DateTime?(DateTime.UtcNow),
                Expires = new DateTime?(DateTime.UtcNow.AddMinutes((double)num)),
                Subject = new ClaimsIdentity((IEnumerable<Claim>)new List<Claim>()
            {
              new Claim("userid", user.UserId.ToString()),
              new Claim("Roles", user.Role)
            }),
                SigningCredentials = new SigningCredentials((SecurityKey)new SymmetricSecurityKey(key), "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256")
            }));
            return new AuthToken()
            {
                Token = str,
                Refreshtoken = Guid.NewGuid().ToString()
            };
        }
    }
}
