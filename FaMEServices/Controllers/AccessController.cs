using FaMEServices.Interfaces;
using FaMEServices.Models;
using FaMEServices.Security.Interfaces;
using FaMEServices.Security.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FaMEServices.Controllers
{
    [Route("api/access")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AccessController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IProfileLogic _profileLogic;
        private readonly IFaMELogger _logger;

        public AccessController(IAuthService authService, IProfileLogic profileLogic, IFaMELogger logger)
        {
            _authService = authService;
            _profileLogic = profileLogic;
            _logger = logger;
        }

        [HttpPost("getaccesstoken")]
        public async Task<ActionResult> GetAccessToken(Login Login)
        {
            try
            {
                var result = await _profileLogic.GetLogedInUserProfile(Login.UserName, Login.Password);
                var loggedInUserDetail = new UserDetail()
                {
                    UserId = result.UserId,
                    UserName = result.UserName,
                    Password = result.Password,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    Role = result.Role
                };
                var accessToken = await _authService.GetAccessToken(loggedInUserDetail);
                await _profileLogic.AddLogin();
                if (accessToken == null)
                {
                    return Unauthorized("Invalid Credentials");
                }
                return Ok(accessToken);
            }
            catch (Exception ex)
            {
                return _logger.CreateApiError(ex.Message);
            }
        }
    }
}
