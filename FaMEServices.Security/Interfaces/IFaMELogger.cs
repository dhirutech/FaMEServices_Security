using Microsoft.AspNetCore.Mvc;

namespace FaMEServices.Security.Interfaces
{
    public interface IFaMELogger
    {
        ObjectResult CreateApiError(string message);
        void LogDebug(string message);
        void LogError(string message);
        void LogWarning(string message);
        void LogInfo(string message);
    }
}
