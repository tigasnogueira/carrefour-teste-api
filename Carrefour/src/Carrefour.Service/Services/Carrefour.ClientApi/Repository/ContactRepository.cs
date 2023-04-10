using Carrefour.ClientApi.Context;
using Carrefour.ClientApi.Interfaces;
using Carrefour.ClientApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Carrefour.ClientApi.Repository;

public class ContactRepository : Repository<Contact>, IContactRepository
{
    public ContactRepository(ClientDbContext context) : base(context) { }

    public async Task<Contact> GetContactByClient(Guid clientId)
    {
        return await Db.Contacts.AsNoTracking()
                .FirstOrDefaultAsync(f => f.ClientId == clientId);
    }
}
