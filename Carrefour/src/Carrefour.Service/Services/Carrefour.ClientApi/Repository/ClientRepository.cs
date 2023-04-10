using Carrefour.ClientApi.Context;
using Carrefour.ClientApi.Interfaces;
using Carrefour.ClientApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Carrefour.ClientApi.Repository;

public class ClientRepository : Repository<ClientModel>, IClientRepository
{
    public ClientRepository(ClientDbContext context) : base(context)
    {
    }

    public async Task<ClientModel> GetClientAddress(Guid id)
    {
        return await Db.Clients.AsNoTracking()
           .Include(c => c.Contact)
           .Include(c => c.Address)
           .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<ClientModel> GetClienteContactAddress(Guid id)
    {
        return await Db.Clients.AsNoTracking()
           .Include(c => c.Address)
           .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<ClientModel> GetContactAddress(Guid id)
    {
        return await Db.Clients.AsNoTracking()
           .Include(c => c.Contact)
           .FirstOrDefaultAsync(c => c.Id == id);
    }
}
