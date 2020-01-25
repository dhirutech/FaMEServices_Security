using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FaMEServices.Repositories.Interfaces;
using FaMEServices.Repositories.Models;

namespace FaMEServices.Repositories.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly List<User> _userList = new List<User>
        {
            new User { UserId = Guid.NewGuid(), UserName = "Admin", Password = "Admin", FirstName = "Dhiraj", LastName = "Bairagi", Role = "Administrator"},
            new User { UserId = Guid.NewGuid(), UserName = "L1User", Password = "L1User", FirstName = "Subham", LastName = "Kumar", Role = "UnitInCharge"},
            new User { UserId = Guid.NewGuid(), UserName = "L2User", Password = "L2User", FirstName = "Rajesh", LastName = "Pandit", Role = "UnitInCharge"},
            new User { UserId = Guid.NewGuid(), UserName = "User", Password = "User", FirstName = "Sujeet", LastName = "Kumar", Role = "User"}
        };

        public async Task<bool> AddLogin()
        {
            return true;
        }

        public async Task<bool> ForgotPassword(Guid userId, string emailId)
        {
            return true;
        }

        public async Task<User> GetLogedInUserProfile(string userName, string password)
        {
            return _userList.FirstOrDefault(u => u.UserName == userName && u.Password == password);
        }

        public async Task<User> GetUserProfile(Guid userId)
        {
            return _userList.FirstOrDefault(u => u.UserId == userId);
        }

        public async Task<bool> ResetPassword(Guid userId, string oldPassword, string newPassword)
        {
            return true;
        }

        public async Task<bool> UpdaeLogin()
        {
            return true;
        }
    }
}
