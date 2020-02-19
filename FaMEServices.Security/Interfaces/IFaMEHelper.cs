using FaMEServices.Security.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FaMEServices.Security.Interfaces
{
    public interface IFaMEHelper
    {
        ObjectResult CreateApiError(Exception ex);
        string RandomPassword(int size);
        ResponseObject BuildResponse(string status, dynamic resData, string message, int resPonseCode);
        void LogDebug(string message);
        void LogError(string message);
        void LogWarning(string message);
        void LogInfo(string message);
    }
}
