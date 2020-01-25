using FaMEServices.Interfaces;
using FaMEServices.Repositories.Interfaces;
using FaMEServices.Security.Interfaces;

namespace FaMEServices.Logics
{
    public class AttendanceLogic : IAttendanceLogic
    {
        private readonly IAttendanceRepository _attendanceRepo;
        private readonly IFaMELogger _logger;

        public AttendanceLogic(IAttendanceRepository attendanceRepo, IFaMELogger logger)
        {
            _attendanceRepo = attendanceRepo;
            _logger = logger;
        }
    }
}
