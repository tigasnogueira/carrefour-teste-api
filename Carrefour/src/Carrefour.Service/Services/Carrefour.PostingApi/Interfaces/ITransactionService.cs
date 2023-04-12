using Carrefour.TransactionApi.Model;

namespace Carrefour.TransactionApi.Interfaces;

public interface ITransactionService
{
    Task<IEnumerable<TransactionModel>> GetAllTransactions();
    Task<TransactionModel> GetTransactionById(Guid id);
    Task<TransactionModel> CreateTransaction(TransactionModel transaction);
    Task UpdateTransaction(TransactionModel transaction);
    Task DeleteTransaction(Guid id);
}
