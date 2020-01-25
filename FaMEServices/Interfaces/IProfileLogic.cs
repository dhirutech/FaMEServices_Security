using FaMEServices.Models;
using FaMEServices.Security.Interfaces;
using System;
using System.Threading.Tasks;

namespace FaMEServices.Interfaces
{
    public interface IProfileLogic
    {
        Task<LoginUser> GetLogedInUserProfile(string userName, string password);
        Task<bool> AddLogin();
        Task<bool> UpdaeLogin();
        Task<LoginUser> GetUserProfile(Guid userId);
        Task<bool> ForgotPassword(Guid userId, string emailId);
        Task<bool> ResetPassword(ResetPassword resetPassword);
    }
}
