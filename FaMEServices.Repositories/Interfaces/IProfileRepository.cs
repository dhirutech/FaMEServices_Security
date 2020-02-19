using FaMEServices.Repositories.Models;
using System;
using System.Threading.Tasks;

namespace FaMEServices.Repositories.Interfaces
{
    public interface IProfileRepository
    {
        Task<UserAccount> GetLogedInUserProfile(string userName, string password);
        Task<bool> AddLogin(AppaAccessLog appaAccessLog);
        Task<bool> UpdateLogin(AppaAccessLog appaAccessLog);
        Task<UserAccount> GetUserProfile(Guid userId);
        Task<UserAccount> ForgotPassword(Guid userId, string emailId, string newPassword);
        Task<UserAccount> ResetPassword(Guid userId, string oldPassword, string newPassword);
    }
}
