using System;
using System.Collections.Generic;

namespace FaMEServices.Repositories.Models
{
    public partial class AppaAccessLog
    {
        public Guid Id { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public bool IsActive { get; set; }
        public Guid UserId { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? UpdatedDateTime { get; set; }

        public virtual UserAccount User { get; set; }
    }
}
