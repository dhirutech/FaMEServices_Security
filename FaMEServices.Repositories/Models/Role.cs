using System;
using System.Collections.Generic;

namespace FaMEServices.Repositories.Models
{
    public partial class Role
    {
        public Role()
        {
            UserAccount = new HashSet<UserAccount>();
        }

        public Guid Id { get; set; }
        public string Type { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? UpdatedDateTime { get; set; }

        public virtual ICollection<UserAccount> UserAccount { get; set; }
    }
}
