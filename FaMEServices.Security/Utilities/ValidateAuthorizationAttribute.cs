using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FaMEServices.Security.Utilities
{
    public class ValidateAuthorizationAttribute : TypeFilterAttribute
    {
        public ValidateAuthorizationAttribute(string claimType, string claimValue)
          : base(typeof(ValidateAuthorizationFilter))
        {
            this.Arguments = new object[1]
            {
        (object) new Claim(claimType, claimValue)
            };
        }
    }
}
