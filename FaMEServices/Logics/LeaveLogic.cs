using FaMEServices.Interfaces;
using FaMEServices.Repositories.Interfaces;
using FaMEServices.Security.Interfaces;

namespace FaMEServices.Logics
{
    public class LeaveLogic : ILeaveLogic
    {
        private readonly ILeaveRepository _leaveRepo;
        private readonly IFaMELogger _logger;

        public LeaveLogic(ILeaveRepository leaveRepo, IFaMELogger logger)
        {
            _leaveRepo = leaveRepo;
            _logger = logger;
        }
    }
}
