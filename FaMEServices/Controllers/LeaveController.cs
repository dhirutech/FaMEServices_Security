using FaMEServices.Interfaces;
using FaMEServices.Security.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FaMEServices.Controllers
{
    [Route("api/leave")]
    [ApiController]
    [ApiVersion("1.0")]
    public class LeaveController : ControllerBase
    {
        private readonly ILeaveLogic _leaveLogic;
        private readonly IFaMELogger _logger;

        public LeaveController(ILeaveLogic leaveLogic, IFaMELogger logger)
        {
            _leaveLogic = leaveLogic;
            _logger = logger;
        }
    }
}