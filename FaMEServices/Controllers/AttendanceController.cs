using FaMEServices.Interfaces;
using FaMEServices.Models;
using FaMEServices.Security.Interfaces;
using FaMEServices.Security.Logics;
using FaMEServices.Security.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FaMEServices.Controllers
{
    [Route("api/attendance")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceLogic _attendanceLogic;
        private readonly IFaMEHelper _helper;

        public AttendanceController(IAttendanceLogic attendanceLogic, IFaMEHelper helper)
        {
            _attendanceLogic = attendanceLogic;
            _helper = helper;
        }

        private IdentityToken InitializeToken()
        {
            var authorizationHeader = HttpContext.Request.Headers["Authorization"];
            return new IdentityToken(AuthenticationHeaderValue.Parse(authorizationHeader));
        }

        [ValidateAuthorization("Roles", "Administrator,UnitInCharge,User")]
        [HttpPost("submitattendance/{type}")]
        public async Task<ActionResult> SubmitAttendance(string type, Attendance attendance)
        {
            var _token = InitializeToken();
            try
            {
                attendance.UserId = _token.UserId;
                var result = await _attendanceLogic.SubmitAttendance(type, attendance);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return _helper.CreateApiError(ex);
            }
        }
    }
}