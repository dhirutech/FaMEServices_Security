using FaMEServices.Interfaces;
using FaMEServices.Models;
using FaMEServices.Security.Interfaces;
using FaMEServices.Security.Logics;
using FaMEServices.Security.Models;
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
        private readonly IFaMELogger _logger;

        public ProfileController(IProfileLogic profileLogic, IFaMELogger logger)
        {
            _profileLogic = profileLogic;
            _logger = logger;
        }

        private IdentityToken InitializeToken()
        {
            var authorizationHeader = HttpContext.Request.Headers["Authorization"];
            return new IdentityToken(AuthenticationHeaderValue.Parse(authorizationHeader));
        }

        [Authorize(Roles = "Administrator,UnitInCharge")]
        [HttpGet("getuserprofile/{userId}")]
        public async Task<ActionResult> GetUserProfile(string userId)
        {
            var _token = InitializeToken();
            try
            {
                var result = await _profileLogic.GetUserProfile(Guid.Parse(userId));
                var loggedInUserDetail = new UserDetail()
                {
                    UserId = result.UserId,
                    UserName = result.UserName,
                    Password = result.Password,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    Role = result.Role
                };
                return Ok(loggedInUserDetail);
            }
            catch (Exception ex)
            {
                return _logger.CreateApiError(ex.Message);
            }
        }

        [Authorize(Roles = "Administrator,UnitInCharge,User")]
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
                return _logger.CreateApiError(ex.Message);
            }
        }

        [Authorize(Roles = "Administrator,UnitInCharge,User")]
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
                return _logger.CreateApiError(ex.Message);
            }
        }
    }
}