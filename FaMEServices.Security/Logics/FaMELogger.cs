using FaMEServices.Security.Interfaces;
using FaMEServices.Security.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;

namespace FaMEServices.Security.Logics
{
    public class FaMELogger : IFaMELogger
    {
        private readonly ILogger<FaMELogger> _log;
        public FaMELogger(ILogger<FaMELogger> log)
        {
            _log = log;
        }
        public ObjectResult CreateApiError(Exception ex)
        {
            _log.LogError(ex.Message);
            return new ObjectResult((object)new ResponseObject()
            {
                Status = "Error",
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                ResponseCode = new int?(500),
                Data = (object)null
            });
        }

        public void LogDebug(string message)
        {
            throw new NotImplementedException();
        }

        public void LogError(string message)
        {
            throw new NotImplementedException();
        }

        public void LogInfo(string message)
        {
            throw new NotImplementedException();
        }

        public void LogWarning(string message)
        {
            throw new NotImplementedException();
        }
    }
}
