using FaMEServices.Repositories.Models;
using System;
using System.Threading.Tasks;

namespace FaMEServices.Repositories.Interfaces
{
    public interface IAttendanceRepository
    {
        Task<Attendance> GetAttendanceById(Guid attenId);
        Task<Client> GetClientById(Guid clientId);
        Task<bool> SubmitAttendance(Attendance attendance);
    }
}
