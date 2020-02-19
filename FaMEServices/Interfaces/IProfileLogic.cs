using FaMEServices.Models;
using System;
using System.Threading.Tasks;

namespace FaMEServices.Interfaces
{
    public interface IProfileLogic
    {
        Task<LoginUser> GetLogedInUserProfile(string userName, string password);
        Task<bool> AddLogin(Guid userId, string token, string refreshtoken);
        Task<bool> UpdateLogin(Guid userId, string token, string refreshtoken);
        Task<ResponseObject> GetUserProfile(Guid userId);
        Task<ResponseObject> ForgotPassword(Guid userId, string emailId);
        Task<ResponseObject> ResetPassword(ResetPassword resetPassword);
    }
}
