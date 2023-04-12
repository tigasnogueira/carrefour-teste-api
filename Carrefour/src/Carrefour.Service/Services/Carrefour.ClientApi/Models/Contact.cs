using Carrefour.Domain.Model;

namespace Carrefour.ClientApi.Models;

public class Contact : EntityModel
{
    public Guid ClientId { get; set; }
    public int Phone { get; set; }
    public string Email { get; set; }

    public ClientModel Client { get; set; }
}
