using FaMEServices.Repositories.Interfaces;
using FaMEServices.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace FaMEServices.Repositories.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        public async Task<bool> AddLogin(AppaAccessLog appaAccessLog)
        {
            using (var context = new androidfameContext())
            {
                await context.AppaAccessLog.AddAsync(appaAccessLog);
                return await context.SaveChangesAsync() > 0;
            }
        }

        public async Task<UserAccount> ForgotPassword(Guid userId, string emailId, string newPassword)
        {
            using (var context = new androidfameContext())
            {
                var user = await context.UserAccount
                                   .FirstOrDefaultAsync(u => u.Id == userId && u.EmailId == emailId && u.IsActive);
                if (user != null)
                {
                    user.Password = newPassword;
                    user.UpdatedDateTime = DateTimeOffset.UtcNow;
                }
                await context.SaveChangesAsync();
                return user;
            }
        }

        public async Task<UserAccount> GetLogedInUserProfile(string userName, string password)
        {
            using (var context = new androidfameContext())
            {
                return await context.UserAccount
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password && u.IsActive);
            }
        }

        public async Task<UserAccount> GetUserProfile(Guid userId)
        {
            using (var context = new androidfameContext())
            {
                return await context.UserAccount
                       .Include(u => u.Role)
                       .Include(u => u.Company)
                       .FirstOrDefaultAsync(u => u.Id == userId && u.IsActive);
            }
        }

        public async Task<UserAccount> ResetPassword(Guid userId, string oldPassword, string newPassword)
        {
            using (var context = new androidfameContext())
            {
                var user = await context.UserAccount
                                   .FirstOrDefaultAsync(u => u.Id == userId && u.Password == oldPassword && u.IsActive);
                if (user != null)
                {
                    user.Password = newPassword;
                    user.UpdatedDateTime = DateTimeOffset.UtcNow;
                }
                await context.SaveChangesAsync();
                return user;
            }
        }

        public async Task<bool> UpdateLogin(AppaAccessLog appaAccessLog)
        {
            using (var context = new androidfameContext())
            {
                var login = await context.AppaAccessLog
                                   .FirstOrDefaultAsync(l => l.UserId == appaAccessLog.UserId && l.IsActive);
                if (login != null)
                {
                    login.Token = appaAccessLog.Token;
                    login.RefreshToken = appaAccessLog.RefreshToken;
                    login.UpdatedDateTime = DateTimeOffset.UtcNow;
                }
                return await context.SaveChangesAsync() > 0;
            }
        }
    }
}
