using FaMEServices.Repositories.Models;
using System;
using System.Threading.Tasks;

namespace FaMEServices.Repositories.Interfaces
{
    public interface IProfileRepository
    {
        Task<User> GetLogedInUserProfile(string userName, string password);
        Task<bool> AddLogin();
        Task<bool> UpdaeLogin();
        Task<User> GetUserProfile(Guid userId);
        Task<bool> ForgotPassword(Guid userId, string emailId);
        Task<bool> ResetPassword(Guid userId, string oldPassword, string newPassword);
    }
}
