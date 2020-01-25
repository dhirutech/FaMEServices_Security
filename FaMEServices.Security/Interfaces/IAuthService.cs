using FaMEServices.Security.Models;
using System.Threading.Tasks;

namespace FaMEServices.Security.Interfaces
{
    public interface IAuthService
    {
        Task<AuthToken> GetAccessToken(UserDetail user);
    }
}
