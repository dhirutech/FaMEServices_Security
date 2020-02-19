using Microsoft.AspNetCore.Mvc;
using System;

namespace FaMEServices.Security.Interfaces
{
    public interface IFaMELogger
    {
        ObjectResult CreateApiError(Exception ex);
        void LogDebug(string message);
        void LogError(string message);
        void LogWarning(string message);
        void LogInfo(string message);
    }
}
