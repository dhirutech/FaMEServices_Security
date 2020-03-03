using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaMEServices.Models
{
    public class Attendance
    {
        private decimal _lat;
        private decimal _lng;
        private decimal? _outlat = null;
        private decimal? _outlng = null;

        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public Guid ClientId { get; set; }
        public DateTimeOffset? CheckInDateTime { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? CheckOutDateTime { get; set; } = DateTimeOffset.Now;
        public decimal CheckInLatitude
        {
            get
            {
                return this._lat;
            }
            set
            {
                if (value < -90 || value > 90)
                {
                    throw new ArgumentOutOfRangeException("Latitude must be between -90 and 90 degrees inclusive.");
                }
                this._lat = value;
            }
        }
        public decimal CheckInLongitude
        {
            get
            {
                return this._lng;
            }
            set
            {
                if (value < -180 || value > 180)
                {
                    throw new ArgumentOutOfRangeException("Longitude must be between -180 and 180 degrees inclusive.");
                }
                this._lng = value;
            }
        }
        public decimal? CheckOutLatitude
        {
            get
            {
                return this._outlat;
            }
            set
            {
                if (value != null && (value < -90 || value > 90))
                {
                    throw new ArgumentOutOfRangeException("Latitude must be between -90 and 90 degrees inclusive.");
                }
                this._outlat = value;
            }
        }
        public decimal? CheckOutLongitude
        {
            get
            {
                return this._outlng;
            }
            set
            {
                if (value != null && (value < -180 || value > 180))
                {
                    throw new ArgumentOutOfRangeException("Longitude must be between -180 and 180 degrees inclusive.");
                }
                this._outlng = value;
            }
        }
    }
}
