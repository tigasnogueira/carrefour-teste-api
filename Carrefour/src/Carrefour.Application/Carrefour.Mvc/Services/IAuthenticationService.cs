using Carrefour.Mvc.Models;

namespace Carrefour.Mvc.Services
{
    public interface IAuthenticationService
    {
        Task<UserloginResponse> Login(UserLogin userLogin);

        Task<UserloginResponse> Register(UserRegister userRegister);
    }
}
