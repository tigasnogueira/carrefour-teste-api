using System.ComponentModel.DataAnnotations;

namespace Carrefour.TransactionApi.ViewModels;

public class TransactionViewModel
{
    [Key]
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public string? Description { get; set; }
    public decimal Amount { get; set; }
    public int AccountId { get; set; }
}
