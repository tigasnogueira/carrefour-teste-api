using Carrefour.ClientApi.Interfaces;
using Carrefour.ClientApi.Models;

namespace Carrefour.ClientApi.Services;

public class ContactService : IContactService
{
    private readonly IContactService _contactService;

    public Task Add(Contact contact)
    {
        return _contactService.Add(contact);
    }

    public Task Update(Contact contact)
    {
        return _contactService.Update(contact);
    }

    public Task Delete(Guid id)
    {
        return _contactService.Delete(id);
    }

    public void Dispose()
    {
        _contactService?.Dispose();
    }
}
