using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FaMEServices.Interfaces;
using FaMEServices.Models;
using FaMEServices.Repositories.Interfaces;
using FaMEServices.Security.Interfaces;

namespace FaMEServices.Logics
{
    public class ProfileLogic : IProfileLogic
    {
        private readonly IProfileRepository _profileRepo;
        private readonly IFaMELogger _logger;

        public ProfileLogic(IProfileRepository profileRepo, IFaMELogger logger)
        {
            _profileRepo = profileRepo;
            _logger = logger;
        }

        public async Task<LoginUser> GetLogedInUserProfile(string userName, string password)
        {
            var result = await _profileRepo.GetLogedInUserProfile(userName, password);
            var loginUser = new LoginUser()
            {
                UserId = result.UserId,
                UserName = result.UserName,
                Password = result.Password,
                FirstName = result.FirstName,
                LastName = result.LastName,
                Role = result.Role
            };
            return loginUser;
        }

        public async Task<LoginUser> GetUserProfile(Guid userId)
        {
            var result = await _profileRepo.GetUserProfile(userId);
            var loginUser = new LoginUser()
            {
                UserId = result.UserId,
                UserName = result.UserName,
                Password = result.Password,
                FirstName = result.FirstName,
                LastName = result.LastName,
                Role = result.Role
            };
            return loginUser;
        }

        public async Task<bool> ForgotPassword(Guid userId, string emailId)
        {
            return await _profileRepo.ForgotPassword(userId, emailId);
        }

        public async Task<bool> ResetPassword(ResetPassword resetPassword)
        {
            return await _profileRepo.ResetPassword(resetPassword.UserId, resetPassword.OldPassword, resetPassword.NewPassword);
        }

        public async Task<bool> AddLogin()
        {
            return await _profileRepo.AddLogin();
        }

        public async Task<bool> UpdaeLogin()
        {
            return await _profileRepo.UpdaeLogin();
        }
    }
}
