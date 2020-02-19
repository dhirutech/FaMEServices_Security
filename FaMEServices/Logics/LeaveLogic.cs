using FaMEServices.Interfaces;
using FaMEServices.Repositories.Interfaces;
using FaMEServices.Security.Interfaces;

namespace FaMEServices.Logics
{
    public class LeaveLogic : ILeaveLogic
    {
        private readonly ILeaveRepository _leaveRepo;
        private readonly IFaMEHelper _helper;

        public LeaveLogic(ILeaveRepository leaveRepo, IFaMEHelper helper)
        {
            _leaveRepo = leaveRepo;
            _helper = helper;
        }
    }
}
