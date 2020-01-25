using System;
using System.Collections.Generic;
using System.Text;

namespace FaMEServices.Security.Models
{
    public class AuthToken
    {
        public string Token { get; set; }
        public string Refreshtoken { get; set; }
    }
}
