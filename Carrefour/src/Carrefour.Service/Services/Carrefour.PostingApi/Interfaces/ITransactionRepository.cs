using Carrefour.TransactionApi.Model;

namespace Carrefour.TransactionApi.Interfaces;

public interface ITransactionRepository
{
    Task<IEnumerable<TransactionModel>> GetAll();
    Task<TransactionModel> GetById(Guid id);
    Task Create(TransactionModel transaction);
    Task Update(TransactionModel transaction);
    Task Delete(TransactionModel transaction);
}
