using FaMEServices.Interfaces;
using FaMEServices.Models;
using FaMEServices.Security.Interfaces;
using FaMEServices.Security.Logics;
using FaMEServices.Security.Utilities;
using FaMEServices.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FaMEServices.Controllers
{
    [Route("api/profile")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileLogic _profileLogic;
        private readonly IFaMEHelper _helper;

        public ProfileController(IProfileLogic profileLogic, IFaMEHelper helper)
        {
            _profileLogic = profileLogic;
            _helper = helper;
        }

        private IdentityToken InitializeToken()
        {
            var authorizationHeader = HttpContext.Request.Headers["Authorization"];
            return new IdentityToken(AuthenticationHeaderValue.Parse(authorizationHeader));
        }

        [ValidateAuthorization("Roles", "Administrator,UnitInCharge")]
        [HttpGet("getuserprofile")]
        public async Task<ActionResult> GetUserProfile()
        {
            var _token = InitializeToken();
            try
            {
                var result = await _profileLogic.GetUserProfile(_token.UserId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return _helper.CreateApiError(ex);
            }
        }

        [ValidateAuthorization("Roles", "Administrator,UnitInCharge,User")]
        [HttpPost("forgotpassword/{emailId}")]
        public async Task<ActionResult> ForgotPassword(string emailId)
        {
            var _token = InitializeToken();
            try
            {
                var result = await _profileLogic.ForgotPassword(_token.UserId, emailId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return _helper.CreateApiError(ex);
            }
        }

        [ValidateAuthorization("Roles", "Administrator,UnitInCharge,User")]
        [HttpPost("resetpassword")]
        public async Task<ActionResult> ResetPassword(ResetPassword resetPassword)
        {
            var _token = InitializeToken();
            try
            {
                resetPassword.UserId = _token.UserId;
                var result = await _profileLogic.ResetPassword(resetPassword);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return _helper.CreateApiError(ex);
            }
        }
    }
}