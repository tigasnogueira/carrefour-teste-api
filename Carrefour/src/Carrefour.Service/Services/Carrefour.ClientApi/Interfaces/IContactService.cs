using Carrefour.ClientApi.Models;

namespace Carrefour.ClientApi.Interfaces;

public interface IContactService : IDisposable
{
    Task Add(Contact contact);
    Task Update(Contact contact);
    Task Delete(Guid id);
}
