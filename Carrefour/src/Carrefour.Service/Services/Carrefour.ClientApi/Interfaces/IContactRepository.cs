using Carrefour.ClientApi.Models;
using Carrefour.Domain.Interfaces;

namespace Carrefour.ClientApi.Interfaces;

public interface IContactRepository : IRepository<Contact>
{
    Task<Contact> GetContactByClient(Guid clientId);
}
