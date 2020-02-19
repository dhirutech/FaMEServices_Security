using System;

namespace FaMEServices.Models
{
    public class LoginUser
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string EmailId { get; set; }
        public DateTimeOffset? Dob { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Company { get; set; }
    }

    public class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
