using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaMEServices.Models
{
    public class ResponseObject
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public int? ResponseCode { get; set; }
        public dynamic Data { get; set; }
    }
}
