using FaMEServices.Security.Interfaces;
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
        public ObjectResult CreateApiError(string message)
        {
            _log.LogError(message);
            var errorStatus = HttpStatusCode.InternalServerError;
            var res = new ObjectResult(message);
            res.StatusCode = (int?)errorStatus;
            return res;
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
