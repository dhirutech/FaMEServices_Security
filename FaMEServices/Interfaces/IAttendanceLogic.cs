using FaMEServices.Models;
using FaMEServices.Security.Models;
using System.Threading.Tasks;

namespace FaMEServices.Interfaces
{
    public interface IAttendanceLogic
    {
        Task<ResponseObject> SubmitAttendance(string type, Attendance attendance);
    }
}
