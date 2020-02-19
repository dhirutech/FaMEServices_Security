using System;
using System.Collections.Generic;

namespace FaMEServices.Repositories.Models
{
    public partial class Company
    {
        public Company()
        {
            UserAccount = new HashSet<UserAccount>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? UpdatedDateTime { get; set; }

        public virtual ICollection<UserAccount> UserAccount { get; set; }
    }
}
