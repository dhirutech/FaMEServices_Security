using System;
using System.Collections.Generic;
using System.Text;

namespace FaMEServices.Repositories.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
    }
}
