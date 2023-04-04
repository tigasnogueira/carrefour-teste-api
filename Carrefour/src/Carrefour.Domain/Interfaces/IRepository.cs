using Carrefour.Domain.Model;
using System.Linq.Expressions;

namespace Carrefour.Domain.Interfaces;

public interface IRepository<TEntity> : IDisposable where TEntity : EntityModel
{
    Task Add(TEntity entity);
    Task<TEntity> GetById(Guid id);
    Task<List<TEntity>> GetAll();
    Task Update(TEntity entity);
    Task Delete(Guid id);
    Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);
    Task<int> SaveChanges();
}