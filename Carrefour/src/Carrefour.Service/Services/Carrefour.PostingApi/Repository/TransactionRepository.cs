using Carrefour.TransactionApi.Context;
using Carrefour.TransactionApi.Interfaces;
using Carrefour.TransactionApi.Model;
using Microsoft.EntityFrameworkCore;

namespace Carrefour.TransactionApi.Repository;

public class TransactionRepository : ITransactionRepository
{
    private readonly ApplicationDbContext _dbContext;

    public TransactionRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<TransactionModel>> GetAll()
    {
        return await _dbContext.Transactions.ToListAsync();
    }

    public async Task<TransactionModel> GetById(Guid id)
    {
        return await _dbContext.Transactions.FindAsync(id);
    }

    public async Task Create(TransactionModel transaction)
    {
        await _dbContext.Transactions.AddAsync(transaction);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(TransactionModel transaction)
    {
        _dbContext.Transactions.Update(transaction);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(TransactionModel transaction)
    {
        _dbContext.Transactions.Remove(transaction);
        await _dbContext.SaveChangesAsync();
    }
}
