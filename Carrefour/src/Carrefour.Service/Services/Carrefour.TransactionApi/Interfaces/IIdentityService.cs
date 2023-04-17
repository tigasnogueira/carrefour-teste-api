using Carrefour.IdentityApi.Models;

namespace Carrefour.TransactionApi.Interfaces;

public interface IIdentityService
{
    Task<UserToken> Register(UserRegister userRegister);
    Task<UserToken> Login(UserLogin userLogin);
    Task<UserClaim> GetClaims(string accessToken);
}
