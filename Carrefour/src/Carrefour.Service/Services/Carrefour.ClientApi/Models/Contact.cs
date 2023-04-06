using Carrefour.Domain.Model;

namespace Carrefour.ClientApi.Models;

public class Contact : EntityModel
{
    public Guid ClientId { get; set; }
    public int Cellphone { get; set; }
    public int HomePhone { get; set; }

    public ClientModel Client { get; set; }
}
