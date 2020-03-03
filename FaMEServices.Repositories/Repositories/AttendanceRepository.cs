using System;
using System.Threading.Tasks;
using FaMEServices.Repositories.Interfaces;
using FaMEServices.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace FaMEServices.Repositories.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        public async Task<Attendance> GetAttendanceById(Guid attenId)
        {
            using (var context = new androidfameContext())
            {
                return await context.Attendance
                                   .FirstOrDefaultAsync(a => a.Id == attenId);
            }
        }

        public async Task<Client> GetClientById(Guid clientId)
        {
            using (var context = new androidfameContext())
            {
                return await context.Client
                                   .FirstOrDefaultAsync(a => a.Id == clientId);
            }
        }

        public async Task<bool> SubmitAttendance(Attendance attendance)
        {
            using (var context = new androidfameContext())
            {
                var atten = await context.Attendance
                                   .FirstOrDefaultAsync(a => a.Id == attendance.Id);
                if (atten != null)
                {
                    atten.CheckOutLatitude = attendance.CheckOutLatitude;
                    atten.CheckOutLongitude = attendance.CheckOutLongitude;
                    atten.CheckOutDateTime = attendance.CheckOutDateTime;
                    atten.OverTime = attendance.OverTime;
                    atten.UpdatedDateTime = DateTimeOffset.UtcNow;
                }
                else
                    await context.Attendance.AddAsync(attendance);

                return await context.SaveChangesAsync() > 0;
            }
        }
    }
}
