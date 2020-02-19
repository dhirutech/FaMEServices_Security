using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using FaMEServices.Security.Models;

namespace FaMEServices.Security.Utilities
{
    public class ValidateAuthorizationFilter : IAuthorizationFilter, IFilterMetadata
    {
        private string[] _claims = new string[0];
        private readonly Claim _claim;

        public ValidateAuthorizationFilter(Claim claim)
        {
            this._claim = claim;
            this._claims = this._claim.Value.Split(",", StringSplitOptions.None);
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User.Claims.Any<Claim>((Func<Claim, bool>)(c =>
            {
                if (c.Type.Contains(this._claim.Type))
                    return ((IEnumerable<string>)this._claims).Contains<string>(c.Value);
                return false;
            })))
                return;
            context.Result = (IActionResult)new UnauthorizedObjectResult((object)this.FormatResponse("Error", (object)null, "Invalid authentication token", 401));
        }

        private ResponseObject FormatResponse(
          string status,
          object resData,
          string message,
          int resPonseCode)
        {
            return new ResponseObject()
            {
                Status = status,
                Message = message,
                StackTrace = (string)null,
                ResponseCode = new int?(resPonseCode),
                Data = resData
            };
        }
    }
}
