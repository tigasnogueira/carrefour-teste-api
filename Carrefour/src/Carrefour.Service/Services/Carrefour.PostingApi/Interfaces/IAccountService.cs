using Carrefour.ClientApi.Models;

namespace Carrefour.TransactionApi.Interfaces;

public interface IAccountService
{
    Task<ClientModel> RegisterUser(string email, string password);
    Task<string> Login(string email, string password);
}
