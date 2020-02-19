using AutoMapper;
using FaMEServices.Interfaces;
using FaMEServices.Models;
using FaMEServices.Repositories.Interfaces;
using FaMEServices.Repositories.Models;
using FaMEServices.Security.Interfaces;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FaMEServices.Logics
{
    public class ProfileLogic : IProfileLogic
    {
        private readonly IProfileRepository _profileRepo;
        private readonly IFaMELogger _logger;
        private readonly IMapper _mapper;

        public ProfileLogic(IMapper mapper, IProfileRepository profileRepo, IFaMELogger logger)
        {
            _mapper = mapper;
            _profileRepo = profileRepo;
            _logger = logger;
        }

        private ResponseObject FormatResponse(string status, dynamic resData, string message, int resPonseCode)
        {
            var resObj = new ResponseObject()
            {
                Status = status,
                Message = message,
                StackTrace = null,
                ResponseCode = resPonseCode,
                Data = resData
            };
            return resObj;
        }

        #region CreateRandomPassword

        // Generate a random number between two numbers    
        private int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        // Generate a random string with a given size and case.   
        // If second parameter is true, the return string is lowercase  
        private string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        // Generate a random password of a given length (optional)  
        private string RandomPassword(int size = 0)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, true));
            builder.Append(RandomNumber(1000, 9999));
            builder.Append(RandomString(2, false));
            return builder.ToString();
        }

        #endregion

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
            return FormatResponse("Success", loginUser, "Profile Details fetched successfully!", (int)HttpStatusCode.OK);
        }

        public async Task<ResponseObject> ForgotPassword(Guid userId, string emailId)
        {
            var newPassword = RandomPassword();
            var result = await _profileRepo.ForgotPassword(userId, emailId, newPassword);
            if (result != null)
            {
                var loginUser = _mapper.Map<LoginUser>(result);
                return FormatResponse("Success", loginUser, "Password reset successfully!", (int)HttpStatusCode.OK);
            }
            else
                return FormatResponse("Failure", null, "User not found, email id is not registered", (int)HttpStatusCode.NotFound);
        }

        public async Task<ResponseObject> ResetPassword(ResetPassword resetPassword)
        {
            var result = await _profileRepo.ResetPassword(resetPassword.UserId, resetPassword.OldPassword, resetPassword.NewPassword);
            if (result != null)
            {
                var loginUser = _mapper.Map<LoginUser>(result);
                return FormatResponse("Success", loginUser, "Password updated successfully!", (int)HttpStatusCode.OK);
            }
            else
                return FormatResponse("Failure", null, "Unable to reset password due to incorrect old password", (int)HttpStatusCode.NotFound);
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
