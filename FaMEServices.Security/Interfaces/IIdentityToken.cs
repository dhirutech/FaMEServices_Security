using System;

namespace FaMEServices.Security.Interfaces
{
    public class IIdentityToken
    {
        Guid UserId { get; }
        string Role { get; }
    }
}
