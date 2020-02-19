using AutoMapper;
using FaMEServices.Interfaces;
using FaMEServices.Models;
using FaMEServices.Repositories.Interfaces;
using FaMEServices.Repositories.Models;
using FaMEServices.Security.Interfaces;
using FaMEServices.Security.Models;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FaMEServices.Logics
{
    public class ProfileLogic : IProfileLogic
    {
        private readonly IProfileRepository _profileRepo;
        private readonly IFaMEHelper _helper;
        private readonly IMapper _mapper;

        public ProfileLogic(IMapper mapper, IProfileRepository profileRepo, IFaMEHelper helper)
        {
            _mapper = mapper;
            _profileRepo = profileRepo;
            _helper = helper;
        }

        public async Task<LoginUser> GetLogedInUserProfile(string userName, string password)
        {
            var result = await _profileRepo.GetLogedInUserProfile(userName, password);
            var loginUser = _mapper.Map<LoginUser>(result);
            return loginUser;
        }

        public async Task<ResponseObject> GetUserProfile(Guid userId)
        {
            var result = await _profileRepo.GetUserProfile(userId);
            var loginUser = _mapper.Map<LoginUser>(result);
            return _helper.BuildResponse("Success", loginUser, "Profile Details fetched successfully!", (int)HttpStatusCode.OK);
        }

        public async Task<ResponseObject> ForgotPassword(Guid userId, string emailId)
        {
            var newPassword = _helper.RandomPassword(5);
            var result = await _profileRepo.ForgotPassword(userId, emailId, newPassword);
            if (result != null)
            {
                var loginUser = _mapper.Map<LoginUser>(result);
                return _helper.BuildResponse("Success", loginUser, "Password reset successfully!", (int)HttpStatusCode.OK);
            }
            else
                return _helper.BuildResponse("Failure", null, "User not found, email id is not registered", (int)HttpStatusCode.NotFound);
        }

        public async Task<ResponseObject> ResetPassword(ResetPassword resetPassword)
        {
            var result = await _profileRepo.ResetPassword(resetPassword.UserId, resetPassword.OldPassword, resetPassword.NewPassword);
            if (result != null)
            {
                var loginUser = _mapper.Map<LoginUser>(result);
                return _helper.BuildResponse("Success", loginUser, "Password updated successfully!", (int)HttpStatusCode.OK);
            }
            else
                return _helper.BuildResponse("Failure", null, "Unable to reset password due to incorrect old password", (int)HttpStatusCode.NotFound);
        }

        public async Task<bool> AddLogin(Guid userId, string token, string refreshtoken)
        {
            var login = new AppaAccessLog()
            {
                Id = Guid.NewGuid(),
                Token = token,
                RefreshToken = refreshtoken,
                UserId = userId,
                IsActive = true,
                CreatedDateTime = DateTimeOffset.UtcNow,
                UpdatedDateTime = DateTimeOffset.UtcNow
            };
            return await _profileRepo.AddLogin(login);
        }

        public async Task<bool> UpdateLogin(Guid userId, string token, string refreshtoken)
        {
            var login = new AppaAccessLog()
            {
                Token = token,
                RefreshToken = refreshtoken,
                UserId = userId
            };
            return await _profileRepo.UpdateLogin(login);
        }
    }
}
