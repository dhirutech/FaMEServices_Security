﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FaMEServices.Security.Models
{
    public class ResponseObject
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public int? ResponseCode { get; set; }
        public object Data { get; set; }
    }
}
