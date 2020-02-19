using FaMEServices.Interfaces;
using FaMEServices.Repositories.Interfaces;
using FaMEServices.Security.Interfaces;

namespace FaMEServices.Logics
{
    public class AttendanceLogic : IAttendanceLogic
    {
        private readonly IAttendanceRepository _attendanceRepo;
        private readonly IFaMEHelper _helper;

        public AttendanceLogic(IAttendanceRepository attendanceRepo, IFaMEHelper helper)
        {
            _attendanceRepo = attendanceRepo;
            _helper = helper;
        }
    }
}
