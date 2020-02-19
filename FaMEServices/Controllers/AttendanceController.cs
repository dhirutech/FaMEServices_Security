using FaMEServices.Interfaces;
using FaMEServices.Security.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
    }
}