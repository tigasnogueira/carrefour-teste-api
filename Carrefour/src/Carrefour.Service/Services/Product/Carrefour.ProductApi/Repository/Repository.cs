using Carrefour.Domain.Interfaces;
using Carrefour.Domain.Model;
using System.Linq.Expressions;

namespace Carrefour.ProductApi.Repository;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
{
    protected readonly MyDbContext Db;
    protected readonly DbSet<TEntity> DbSet;

    protected Repository(MyDbContext db)
    {
        Db = db;
        DbSet = db.Set<TEntity>();
    }

    public async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
    {
        return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
    }

    public virtual async Task<TEntity> GetById(Guid id)
    {
        return await DbSet.FindAsync(id);
    }

    public virtual async Task<List<TEntity>> GetAll()
    {
        return await DbSet.ToListAsync();
    }

    public virtual async Task Add(TEntity entity)
    {
        DbSet.Add(entity);
        await SaveChanges();
    }

    public virtual async Task Update(TEntity entity)
    {
        DbSet.Update(entity);
        await SaveChanges();
    }

    public virtual async Task Delete(Guid id)
    {
        DbSet.Remove(new TEntity { Id = id });
        await SaveChanges();
    }

    public async Task<int> SaveChanges()
    {
        return await Db.SaveChangesAsync();
    }

    public void Dispose()
    {
        Db?.Dispose();
    }
}