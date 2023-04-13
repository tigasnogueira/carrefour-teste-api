using Carrefour.Domain.Model;
using Carrefour.IdentityApi.Models;

namespace Carrefour.TransactionApi.Model;

public class TransactionModel : EntityModel
{
    public DateTime Date { get; set; }
    public string? Description { get; set; }
    public decimal Amount { get; set; }
    public int AccountId { get; set; }
    public string UserId { get; set; } // foreign key to ApplicationUser

    public virtual UserToken User { get; set; }
}


public class Debit : TransactionModel
{
}

public class Credit : TransactionModel
{
}

