using FaMEServices.Security.Interfaces;
using FaMEServices.Security.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Text;

namespace FaMEServices.Security.Logics
{
    public class FaMEHelper : IFaMEHelper
    {
        private readonly ILogger<FaMEHelper> _log;
        public FaMEHelper(ILogger<FaMEHelper> log)
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

        // Generate a random password of a given length (optional)
        public string RandomPassword(int size = 0)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, true));
            builder.Append(RandomNumber(1000, 9999));
            builder.Append(RandomString(2, false));
            return builder.ToString();
        }

        public ResponseObject BuildResponse(string status, dynamic resData, string message, int resPonseCode)
        {
            var resObj = new ResponseObject()
            {
                Status = status,
                Message = message,
                StackTrace = null,
                ResponseCode = resPonseCode,
                Data = resData
            };
            return resObj;
        }

        #region CreateRandomPassword

        // Generate a random number between two numbers    
        private int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        // Generate a random string with a given size and case.   
        // If second parameter is true, the return string is lowercase  
        private string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        #endregion

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
