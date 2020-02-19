using System;

namespace FaMEServices.Models
{
    public class ResetPassword
    {
        public Guid UserId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
