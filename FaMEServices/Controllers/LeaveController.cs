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
        private readonly IFaMEHelper _helper;

        public LeaveController(ILeaveLogic leaveLogic, IFaMEHelper helper)
        {
            _leaveLogic = leaveLogic;
            _helper = helper;
        }
    }
}