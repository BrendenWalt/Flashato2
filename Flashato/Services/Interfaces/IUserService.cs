using Flashato.Models.Requests;
using Microsoft.AspNet.Identity;

namespace Flashato.Services.Interfaces
{
    public interface IUserService
    {
        IdentityResult Register(RegistrationRequest model);
        string GetCurrentUserId();
    }
}