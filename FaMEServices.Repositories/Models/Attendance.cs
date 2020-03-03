using System;
using System.Collections.Generic;

namespace FaMEServices.Repositories.Models
{
    public partial class Attendance
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ClientId { get; set; }
        public DateTimeOffset? CheckInDateTime { get; set; }
        public DateTimeOffset? CheckOutDateTime { get; set; }
        public double? OverTime { get; set; }
        public decimal CheckInLatitude { get; set; }
        public decimal CheckInLongitude { get; set; }
        public decimal? CheckOutLatitude { get; set; }
        public decimal? CheckOutLongitude { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? UpdatedDateTime { get; set; }

        public virtual Client Client { get; set; }
        public virtual UserAccount User { get; set; }
    }
}
